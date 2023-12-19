using Photon.Pun;
using UnityEngine;

public class GroundManager : MonoBehaviour, IGroundGimmick
{
    private bool InitialSpawnPoint = false;
    private bool GimmickTriggerd = false;
    private bool GimmickCleard = false;

    public bool m_GimmickTriggerd => GimmickTriggerd;
    public bool m_GimmickCleard => GimmickCleard;

    public void StartButtle()
    {
        if (GimmickTriggerd) return;

        GetComponent<PhotonView>().RPC(nameof(StartGimmick), RpcTarget.AllBuffered);
        if (InitialSpawnPoint) // �Q�[���X�^�[�g�n�_��
        {
            GetComponent<PhotonView>().RPC(nameof(MakeWarpMarker), RpcTarget.AllBuffered);
            return; 
        }

        Instantiates();
    }

    [PunRPC]
    public void MakeWarpMarker()
    {
        Debug.Log("���[�v�n�_����");
    }

    [PunRPC]
    void StartGimmick()
    {
        if (GimmickTriggerd) { return; }  //StartButtle �̒��ɏ����Ă邯�ǈꉞ
        Debug.Log("�퓬�J�n");
        GimmickTriggerd = true;
    }

    void Instantiates()
    {
        float Rand(float min, float max)
        {
            return Random.Range(min, max);
        }

        //PhotonNetwork.Instantiate(GeneralSettings.Instance.m_Prehabs.Enemy.name, transform.position + new Vector3(0, 3, 0), Quaternion.identity);
        //PhotonNetwork.Instantiate(GeneralSettings.Instance.m_Prehabs.Enemy.name, transform.position + new Vector3(0, 3, 1), Quaternion.identity);
        //PhotonNetwork.Instantiate(GeneralSettings.Instance.m_Prehabs.Enemy.name, transform.position + new Vector3(0, 3, -1), Quaternion.identity);
        //PhotonNetwork.Instantiate(GeneralSettings.Instance.m_Prehabs.Enemy.name, transform.position + new Vector3(0, 3, 0), Quaternion.identity);
        //PhotonNetwork.Instantiate(GeneralSettings.Instance.m_Prehabs.Enemy.name, transform.position + new Vector3(0, 3, 1), Quaternion.identity);

        for(int i = 0;  i < (int)Rand(1, 5); i++)
        {
            var randomPos = new Vector3(Rand(-1f, 1f), 0, Rand(-1f, 1f)).normalized * Rand(0f, 9f);
            randomPos.y = 1f;
            PhotonNetwork.Instantiate(GeneralSettings.Instance.m_Prehabs.Enemy.name, transform.position + randomPos, Quaternion.identity);
        }
    }
}
