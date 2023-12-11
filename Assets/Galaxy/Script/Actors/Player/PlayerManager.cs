using UnityEngine;
using Photon.Pun;

public class PlayerManager : MonoBehaviour
{
    private PhotonView view;

    internal GameObject m_Camera;

    PlayerStatusManager StatusManager = new PlayerStatusManager();
    PlayerStatePresenter StatePresenter = new PlayerStatePresenter();
    [SerializeField]
    UIManager uiManager;

    public PlayerStatusManager m_StatusManager => StatusManager;
    public PlayerStatePresenter m_StatePresenter => StatePresenter;

    private void Init()
    {
        view = GetComponent<PhotonView>();
        m_StatePresenter.OnStartPlayState();
        SetUIManager();
    }

    void Start()
    {
        Init();
        //PhotonNetwork.Instantiate(GeneralSettings.Instance.m_Prehabs.FlagmentGuide.name, new Vector3(0, 3, 0), Quaternion.identity);
        //PhotonNetwork.Instantiate(GeneralSettings.Instance.m_Prehabs.FlagmentLight.name, new Vector3(0, 3, 1), Quaternion.identity);
        //PhotonNetwork.Instantiate(GeneralSettings.Instance.m_Prehabs.FlagmentMark.name, new Vector3(0, 3, -1), Quaternion.identity);
        //PhotonNetwork.Instantiate(GeneralSettings.Instance.m_Prehabs.FlagmentGuide.name, new Vector3(0, 3, 0), Quaternion.identity);
        //PhotonNetwork.Instantiate(GeneralSettings.Instance.m_Prehabs.FlagmentLight.name, new Vector3(0, 3, 1), Quaternion.identity);
        //PhotonNetwork.Instantiate(GeneralSettings.Instance.m_Prehabs.FlagmentMark.name, new Vector3(0, 3, -1), Quaternion.identity);
    }

    void Update()
    {
        PlayerStateUpdater.ChangeState(StatePresenter);
        if (m_StatePresenter.canPickUp && PlayerInputPresenter.SwitchGetItem)
        {
            GetItem();
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