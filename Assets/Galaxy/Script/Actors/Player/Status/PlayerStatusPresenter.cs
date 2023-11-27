using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusPresenter : MonoBehaviour
{
    PlayerStatusManager statusManager = new PlayerStatusManager();
    public PlayerStatusManager m_StatusManager => statusManager;

    /// <summary> �����͕K���{�̒l�ɂ��Ă������� </summary>
    public PlayerStatusManager Damage(uint damage)
    {
        statusManager.calcHp = (int)-damage;
        return statusManager;
    }

    /// <summary> �����͕K���{�̒l�ɂ��Ă������� </summary>
    public PlayerStatusManager Heal(uint heal)
    {
        statusManager.calcHp = (int)heal;
        return statusManager;
    }

    public PlayerStatusManager Respawn()
    {
        statusManager.calcHp = GeneralSettings.Instance.m_PlayerSettings.Hp;
        return statusManager;
    }

    /// <summary> �����͕K���{�̒l�ɂ��Ă������� </summary>
    public PlayerStatusManager GetFlagment(uint getFlagment)
    {
        statusManager.calcFlagment = (int)getFlagment;
        return statusManager;
    }

    /// <summary> �����͕K���{�̒l�ɂ��Ă������� </summary>
    public PlayerStatusManager UseFlagment(uint useFlagment)
    {
        statusManager.calcFlagment = (int)-useFlagment;
        return statusManager;
    }
}
