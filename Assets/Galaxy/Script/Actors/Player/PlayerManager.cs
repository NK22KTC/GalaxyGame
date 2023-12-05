using System;
using UnityEngine;
using Photon.Pun;
//using Cysharp.Threading.Tasks;

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

        if (!nearestItem.TryGetComponent(out IFragmentable itemFragment)) { return; }

        if (PlayerInputPresenter.SwitchGetItem)
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
            if(!itemFragment.PassPhotonView(out PhotonView view).IsMine)
            {
                //�����̂łȂ��Ȃ珊�L�������N�G�X�g����
                view.RequestOwnership();
            }
            else
            {
                //�����̂ł���Α����ɍ폜����
                PhotonNetwork.Destroy(view);
            }

            Debug.Log(m_StatusPresenter.m_StatusManager.FlagGuide);
            Debug.Log(m_StatusPresenter.m_StatusManager.FlagLight);
            Debug.Log(m_StatusPresenter.m_StatusManager.FlagMark);
        }
    }

    void DestroyAction(PhotonView view)
    {
        PhotonNetwork.Destroy(view);
    }
}