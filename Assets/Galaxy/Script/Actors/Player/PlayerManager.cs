using UnityEngine;
using Photon.Pun;
using Cysharp.Threading.Tasks;

public class PlayerManager : MonoBehaviour
{
    Rigidbody rb;

    internal GameObject m_Camera;

    PlayerStatusPresenter m_StatusPresenter = new PlayerStatusPresenter();
    PlayerStatePresenter StatePresenter = new PlayerStatePresenter();
    //PlayerControllerPresenter m_ControlPresenter;
    [SerializeField]
    UIManager uiManager;

    public PlayerStatePresenter m_StatePresenter => StatePresenter;

    private void Init()
    {
        rb = GetComponent<Rigidbody>();

        m_StatePresenter.OnStartPlayState();
        SetUIManager();
    }

    void Start()
    {
        Init();
    }

    void Update()
    {
        PlayerStateUpdater.ChangeState(StatePresenter);
        GetItem();
    }

    void SetUIManager()
    {
        uiManager = transform.GetComponentInChildren<UIManager>();
        uiManager.ShareValue(this);
        uiManager = null;
    }

    void LateUpdate()
    {

    }

    void GetItem()
    {
        var items = Physics.OverlapSphere(transform.position, 5, 2 << 9);
        if (items.Length == 0) { return; }

        var nearestItem = ItemAcquisitionCalculate.GetNearestItem(items, transform.position);

        if (!nearestItem.TryGetComponent(out IFragment itemFragment)) { return; }

        if (PlayerInputPresenter.SwitchGetItem)
        {
            GetFlagment(itemFragment);
        }
    }

    async void GetFlagment(IFragment itemFragment)
    {
        switch (itemFragment.FragmentType)
        {
            case FragmentType.Guide:
                m_StatusPresenter.GetFlagment(1).UpdateFlagGuide();
                break;
            case FragmentType.Light:
                m_StatusPresenter.GetFlagment(1).UpdateFlagLight();
                break;
            case FragmentType.Mark:
                m_StatusPresenter.GetFlagment(1).UpdateFlagMark();
                break;
        }

        //自分が所有しているネットワークオブジェクトかを取得
        if (!itemFragment.PassPhotonView(out PhotonView view).IsMine)
        {
            //自分のでないなら所有権をリクエストする
            view.RequestOwnership();
            //リクエストが承認されたら
            await UniTask.WaitUntil(() => itemFragment.OwnershipTransfered);

            Destroying(view);
        }
        else
        {
            //自分のであれば即座に削除する
            Destroying(view);
        }
    }

    void Destroying(PhotonView view)
    {
        PhotonNetwork.Destroy(view);
    }

    async UniTask<bool> OwnerTransferWait(bool transfered)
    {
        await UniTask.WaitUntil(() => transfered);
        return true;
    }
}