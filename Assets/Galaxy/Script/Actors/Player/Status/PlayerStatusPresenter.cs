
public static class PlayerStatusPresenter
{
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
