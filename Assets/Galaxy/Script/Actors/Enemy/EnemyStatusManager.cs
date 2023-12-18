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
    }

    public void Heal(int healNum)
    {
        //�G�̗̑͂��񕜂����鎖�͑����Ȃ�����Ƃ肠�����R�����g��
        //hp += healNum;
    }

    public async void Damage(int damageNum, PlayerManager manager)
    {
        hp -= damageNum;
        if(hp <= 0)
        {
            await NetworkObjectsGettings.CheckOwner(manager, netObj);
            DestroyObj();
        }
    }

    void DestroyObj()
    {
        PhotonNetwork.Destroy(netObj.PassPhotonView());
    }
}
