using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyStatusManager : IActorStatus, IHitPointHandler
{
    private int hp;

    private readonly INetworkObject netObj;
    public int m_Hp => hp;
    public int m_Power => GeneralSettings.Instance.m_EnemySettings.Power;

    public EnemyStatusManager(INetworkObject netObj)
    {
        hp = GeneralSettings.Instance.m_EnemySettings.Hp;
        this.netObj = netObj;
        Debug.Log(this.netObj);
    }

    public void Heal(int healNum)
    {
        //hp += healNum;
    }

    public async void Damage(int damageNum, PlayerManager manager)
    {
        hp -= damageNum;
        Debug.Log(hp);
        if(hp <= 0)
        {
            var view = await NetworkObjectsGettings.CheckOwner(manager, netObj);
            DestroyObj(view);
        }
    }

    void DestroyObj(PhotonView view)
    {
        PhotonNetwork.Destroy(netObj.PassPhotonView());
    }
}
