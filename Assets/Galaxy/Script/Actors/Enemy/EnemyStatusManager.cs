using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyStatusManager : IActorStatus, IHitPointHandler
{
    private EnemyManager EnemyManager;

    private int hp;
    private int power;

    private readonly INetworkObject netObj;
    public int m_Hp => hp;
    public int m_Power => power;

    public EnemyStatusManager(EnemyManager EnemyManager)
    {
        hp = GeneralSettings.Instance.m_EnemySettings.Hp;
        power = GeneralSettings.Instance.m_EnemySettings.Power;

        this.EnemyManager = EnemyManager;
        this.netObj = EnemyManager;
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
            EnemyManager.m_GroundGimmick.UpdateStatus(EnemyManager);
            DropItems();
            DestroyObj();
        }
    }

    private void DropItems()
    {
        PhotonNetwork.Instantiate(GeneralSettings.Instance.m_Prehabs.FlagmentLight.name, EnemyManager.transform.position, EnemyManager.transform.rotation);
    }

    void DestroyObj()
    {
        PhotonNetwork.Destroy(netObj.PassPhotonView());
    }
}
