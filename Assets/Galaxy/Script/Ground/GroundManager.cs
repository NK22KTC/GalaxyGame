using Photon.Pun;
using UnityEngine;

public class GroundManager : MonoBehaviour, IGroundGimmick
{
    private bool m_GimmickStarted = false;
    private bool m_GimmickCleard = false;

    public bool GimmickTriggerd => m_GimmickStarted;
    public bool GimmickCleard => m_GimmickCleard;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButtle()
    {
        if (m_GimmickStarted) return;

        GetComponent<PhotonView>().RPC(nameof(StartGimmick), RpcTarget.AllBuffered);
        Instantiates();
    }

    public void MakeWarpMaker()
    {

    }

    [PunRPC]
    void StartGimmick()
    {
        Debug.Log("êÌì¨äJén");
        m_GimmickStarted = true;
    }

    void Instantiates()
    {
        PhotonNetwork.Instantiate(GeneralSettings.Instance.m_Prehabs.FlagmentGuide.name, transform.position + new Vector3(0, 3, 0), Quaternion.identity);
        PhotonNetwork.Instantiate(GeneralSettings.Instance.m_Prehabs.FlagmentLight.name, transform.position + new Vector3(0, 3, 1), Quaternion.identity);
        PhotonNetwork.Instantiate(GeneralSettings.Instance.m_Prehabs.FlagmentMark.name, transform.position + new Vector3(0, 3, -1), Quaternion.identity);
        PhotonNetwork.Instantiate(GeneralSettings.Instance.m_Prehabs.FlagmentGuide.name, transform.position + new Vector3(0, 3, 0), Quaternion.identity);
        PhotonNetwork.Instantiate(GeneralSettings.Instance.m_Prehabs.FlagmentLight.name, transform.position + new Vector3(0, 3, 1), Quaternion.identity);
        PhotonNetwork.Instantiate(GeneralSettings.Instance.m_Prehabs.FlagmentMark.name, transform.position + new Vector3(0, 3, -1), Quaternion.identity);
    }
}
