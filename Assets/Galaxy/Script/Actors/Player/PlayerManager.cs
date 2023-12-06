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

        //���������L���Ă���l�b�g���[�N�I�u�W�F�N�g�����擾
        if (!itemFragment.PassPhotonView(out PhotonView view).IsMine)
        {
            //�����̂łȂ��Ȃ珊�L�������N�G�X�g����
            view.RequestOwnership();
            //���N�G�X�g�����F���ꂽ��
            await UniTask.WaitUntil(() => itemFragment.OwnershipTransfered);

            Destroying(view);
        }
        else
        {
            //�����̂ł���Α����ɍ폜����
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