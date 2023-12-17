using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatusManager : IActorStatus
{
    private int hp;

    public int m_Hp => hp;

    public int m_Power => GeneralSettings.Instance.m_EnemySettings.Power;

    public EnemyStatusManager()
    {
        hp = GeneralSettings.Instance.m_EnemySettings.Hp;
    }
}
