
public static class PlayerStatusPresenter
{
    /// <summary> �����͕K���{�̒l�ɂ��Ă������� </summary>
    public static PlayerStatusManager Damage(PlayerStatusManager statusManager, uint damage)
    {
        statusManager.calcHp = (int)-damage;
        return statusManager;
    }

    /// <summary> �����͕K���{�̒l�ɂ��Ă������� </summary>
    public static PlayerStatusManager Heal(PlayerStatusManager statusManager, uint heal)
    {
        statusManager.calcHp = (int)heal;
        return statusManager;
    }

    public static PlayerStatusManager Respawn(PlayerStatusManager statusManager)
    {
        statusManager.calcHp = GeneralSettings.Instance.m_PlayerSettings.Hp;
        return statusManager;
    }

    /// <summary> �����͕K���{�̒l�ɂ��Ă������� </summary>
    public static PlayerStatusManager GetFlagment(PlayerStatusManager statusManager, uint getFlagment)
    {
        statusManager.calcFlagment = (int)getFlagment;
        return statusManager;
    }

    /// <summary> �����͕K���{�̒l�ɂ��Ă������� </summary>
    public static PlayerStatusManager UseFlagment(PlayerStatusManager statusManager, uint useFlagment)
    {
        statusManager.calcFlagment = (int)-useFlagment;
        return statusManager;
    }
}
