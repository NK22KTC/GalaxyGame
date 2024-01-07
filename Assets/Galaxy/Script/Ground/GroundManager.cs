using Photon.Pun;
using UnityEngine;

public class GroundManager : MonoBehaviour, IGroundGimmick
{
    [SerializeField]
    private bool InitialSpawnPoint = false;
    private bool GimmickTriggerd = false;
    private bool GimmickCleard = false;

    public bool m_GimmickTriggerd => GimmickTriggerd;
    public bool m_GimmickCleard => GimmickCleard;

    public void StartButtle()
    {
        if (GimmickTriggerd) return;

        GetComponent<PhotonView>().RPC(nameof(StartGimmick), RpcTarget.AllBuffered);
        if (InitialSpawnPoint) // スポーン地点はギミックを発動させない
        {
            GetComponent<PhotonView>().RPC(nameof(MakeWarpMarker), RpcTarget.AllBuffered);
            return; 
        }

        Instantiate();
    }

    [PunRPC]
    public void MakeWarpMarker()
    {
        Debug.Log("ワープ地点生成");
    }

    [PunRPC]
    void StartGimmick()
    {
        if (GimmickTriggerd) { return; }  //StartButtle の中に書いてるけど一応
        Debug.Log("戦闘開始");
        GimmickTriggerd = true;
    }

    void Instantiate()
    {
        float Rand(float min, float max)
        {
            return Random.Range(min, max);
        }

        for(int i = 0;  i < (int)Rand(1, 5); i++)
        {
            var randomPos = new Vector3(Rand(-1f, 1f), 0, Rand(-1f, 1f)).normalized * Rand(0f, 9f);
            randomPos.y = 1f;
            PhotonNetwork.Instantiate(GeneralSettings.Instance.m_Prehabs.Enemy.name, transform.position + randomPos, Quaternion.identity);
        }
    }
}
