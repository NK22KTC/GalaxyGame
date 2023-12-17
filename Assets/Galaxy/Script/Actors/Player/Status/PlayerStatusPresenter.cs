
public static class PlayerStatusPresenter
{
    /// <summary> 引数は必ず＋の値にしてください </summary>
    public static PlayerStatusManager GetFlagment(PlayerStatusManager statusManager, uint getFlagment)
    {
        statusManager.calcFlagment = (int)getFlagment;
        return statusManager;
    }

    /// <summary> 引数は必ず＋の値にしてください </summary>
    public static PlayerStatusManager UseFlagment(PlayerStatusManager statusManager, uint useFlagment)
    {
        statusManager.calcFlagment = (int)-useFlagment;
        return statusManager;
    }
}
