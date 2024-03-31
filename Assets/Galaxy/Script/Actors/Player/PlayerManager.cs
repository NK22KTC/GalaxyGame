using UnityEngine;
using Photon.Pun;

public class PlayerManager : MonoBehaviour, IPlayer
{
    private PhotonView view;

    internal GameObject m_Camera;

    private PlayerStatusManager StatusManager;
    private PlayerStatePresenter StatePresenter;
    private PlayerAttackManager AttackManager;
    [SerializeField]
    UIManager uiManager;

    public PlayerStatusManager m_StatusManager => StatusManager;
    public PlayerStatePresenter m_StatePresenter => StatePresenter;
    public PlayerAttackManager m_AttackManager => AttackManager;

    public IActorStatus m_ActorStatus => m_StatusManager;

    public IHitPointHandler m_HitPointHandler => m_StatusManager;

    private void Init()
    {
        StatusManager = new PlayerStatusManager();
        StatePresenter = new PlayerStatePresenter();
        AttackManager = AttackManager = new PlayerAttackManager(gameObject, m_Camera);

        view = GetComponent<PhotonView>();
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
        if (m_StatePresenter.canPickUp && PlayerInputPresenter.SwitchGetItem)
        {
            GetItem();
        }

        if (m_StatePresenter.isAttacking)
        {
            m_AttackManager.Attack();
        }
    }

    void SetUIManager()
    {
        uiManager = transform.GetComponentInChildren<UIManager>();
        uiManager.ShareValue(this);
        uiManager = null;
    }

    async void GetItem()
    {
        var networkItem = await NetworkObjectsGettings.GetNetworkObject(this);
        if (networkItem is IFragment)
        {
            PlayerStatusPresenter.GetFlagment(m_StatusManager, 1).UpdateFlag(((IFragment)networkItem).FragmentType);

            PhotonNetwork.Destroy(networkItem.PassPhotonView());
        }
        if (networkItem is IGameButton)
        {
            ((IGameButton)networkItem).Pushing(view);
        }
    }
}