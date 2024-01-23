using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour, IGroundGimmick
{
    [SerializeField]
    private bool InitialSpawnPoint = false;
    private bool GimmickTriggerd = false;
    private bool GimmickCleard = false;

    private List<IEnemy> enemies = new List<IEnemy>();

    public bool m_GimmickTriggerd => GimmickTriggerd;
    public bool m_GimmickCleard => GimmickCleard;

    public void StartButtle()
    {
        if (GimmickTriggerd) return;

        var randPos = new Vector3(Rand(-1f, 1f), 0, Rand(-1f, 1f)).normalized * Rand(0f, 9f);
        PhotonNetwork.Instantiate(GeneralSettings.Instance.m_Prehabs.FlagmentGuide.name, transform.position + randPos, Quaternion.identity);  //チュートリアル

        if (InitialSpawnPoint) // スポーン地点はギミックを発動させない
        {
            GetComponent<PhotonView>().RPC(nameof(MakeWarpMarker), RpcTarget.AllBuffered);
            GimmickTriggerd = true;
        }
        else
        {
            GetComponent<PhotonView>().RPC(nameof(StartGimmick), RpcTarget.AllBuffered);
            Instantiate();
        }
    }

    [PunRPC]
    public void UpdateStatus(IEnemy enemy)
    {
        enemies.Remove(enemy);
        if(enemies.Count == 0)
        {
            Debug.Log("StageClear!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            GimmickCleard = true;
            GetComponent<PhotonView>().RPC(nameof(MakeWarpMarker), RpcTarget.AllBuffered);
        }
    }

    [PunRPC]
    public void MakeWarpMarker()
    {
        Debug.Log("ワープ地点生成");
        // ワープ地点の数だけFlagmentMarkを生成する

        if (InitialSpawnPoint) { return; }  //初期地点は最初からワープ可能にする、もしくはFlagmentMark1個消費だけでワープ地点可能にする

        var randPos = new Vector3(Rand(-1f, 1f), 0, Rand(-1f, 1f)).normalized * Rand(0f, 9f);
        PhotonNetwork.Instantiate(GeneralSettings.Instance.m_Prehabs.FlagmentMark.name, transform.position + randPos, Quaternion.identity);
    }

    [PunRPC]
    void StartGimmick()
    {
        if (GimmickTriggerd) { return; }  //StartButtle の中に書いてるけど一応
        Debug.Log("戦闘開始");
        GimmickTriggerd = true;
    }

    [PunRPC]
    private void SetInitialSpawnPoint() => InitialSpawnPoint = true;

    public GroundManager SetInitialPoint()
    {
        GetComponent<PhotonView>().RPC(nameof(SetInitialSpawnPoint), RpcTarget.AllBuffered);
        return this;
    }
    public SpawnPoint CreateSpawnPoint()
    {
        return PhotonNetwork.Instantiate(GeneralSettings.Instance.m_Prehabs.Spawnpoint.name,
                                     new Vector3(transform.position.x, transform.position.y + 1.1f, transform.position.z),
                                     Quaternion.identity).GetComponent<SpawnPoint>();
    }

    void Instantiate()
    {
        for(int i = 0;  i < (int)Rand(1, 5); i++)
        {
            var randomPos = new Vector3(Rand(-1f, 1f), 0, Rand(-1f, 1f)).normalized * Rand(0f, 9f);
            randomPos.y = 1f;
            var enemy = PhotonNetwork.Instantiate(GeneralSettings.Instance.m_Prehabs.Enemy.name, transform.position + randomPos, Quaternion.identity);


            var ene = enemy.GetComponent<IEnemy>();
            enemies.Add(ene);
            ene.GetGroundInfo(this);
        }
    }


    private float Rand(float min, float max)
    {
        return Random.Range(min, max);
    }
}
