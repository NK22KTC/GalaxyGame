
public static class PlayerStatusPresenter
{
    /// <summary> ˆø”‚Í•K‚¸{‚Ì’l‚É‚µ‚Ä‚­‚¾‚³‚¢ </summary>
    public static PlayerStatusManager GetFlagment(PlayerStatusManager statusManager, uint getFlagment)
    {
        statusManager.calcFlagment = (int)getFlagment;
        return statusManager;
    }

    /// <summary> ˆø”‚Í•K‚¸{‚Ì’l‚É‚µ‚Ä‚­‚¾‚³‚¢ </summary>
    public static PlayerStatusManager UseFlagment(PlayerStatusManager statusManager, uint useFlagment)
    {
        statusManager.calcFlagment = (int)-useFlagment;
        return statusManager;
    }
}
