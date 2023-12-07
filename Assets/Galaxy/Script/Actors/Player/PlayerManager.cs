using UnityEngine;
using Photon.Pun;

public class PlayerManager : MonoBehaviour
{
    internal GameObject m_Camera;

    PlayerStatusPresenter StatusPresenter = new PlayerStatusPresenter();
    PlayerStatePresenter StatePresenter = new PlayerStatePresenter();
    [SerializeField]
    UIManager uiManager;

    public PlayerStatusPresenter m_StatusPresenter => StatusPresenter;
    public PlayerStatePresenter m_StatePresenter => StatePresenter;

    private void Init()
    {
        m_StatePresenter.OnStartPlayState();
        SetUIManager();
    }

    void Start()
    {
        Init();
        PhotonNetwork.Instantiate(GeneralSettings.Instance.m_Prehabs.FlagmentGuide.name, new Vector3(0, 3, 0), Quaternion.identity);
        PhotonNetwork.Instantiate(GeneralSettings.Instance.m_Prehabs.FlagmentLight.name, new Vector3(0, 3, 1), Quaternion.identity);
        PhotonNetwork.Instantiate(GeneralSettings.Instance.m_Prehabs.FlagmentMark.name, new Vector3(0, 3, -1), Quaternion.identity);
        PhotonNetwork.Instantiate(GeneralSettings.Instance.m_Prehabs.FlagmentGuide.name, new Vector3(0, 3, 0), Quaternion.identity);
        PhotonNetwork.Instantiate(GeneralSettings.Instance.m_Prehabs.FlagmentLight.name, new Vector3(0, 3, 1), Quaternion.identity);
        PhotonNetwork.Instantiate(GeneralSettings.Instance.m_Prehabs.FlagmentMark.name, new Vector3(0, 3, -1), Quaternion.identity);
    }

    void Update()
    {
        PlayerStateUpdater.ChangeState(StatePresenter);
        
        if (PlayerInputPresenter.SwitchGetItem)
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
            m_StatusPresenter.GetFlagment(1).UpdateFlag(((IFragment)networkItem).FragmentType);
        }
        //if(networkItem is IItem)
        //{
            
        //}
    }
}