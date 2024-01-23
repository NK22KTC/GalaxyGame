using System;
using UnityEngine;

public class PlayerStatusManager : IActorStatus, IHitPointHandler
{
    private int hp;
    private int power;

    private int flagGuide = 0;
    private int flagMark = 0;
    private int flagLight = 0;
    public int calcFlagment;

    public int m_Hp => hp;
    public int m_Power => power;

    public PlayerStatusManager()
    {
        hp = GeneralSettings.Instance.m_PlayerSettings.Hp;
        power = GeneralSettings.Instance.m_PlayerSettings.Power;
    }

    public void Heal(int healNum)
    {
        if(hp + healNum > GeneralSettings.Instance.m_PlayerSettings.Hp)
        {
            hp = GeneralSettings.Instance.m_PlayerSettings.Hp;
            return;
        }
        hp += healNum;
    }

    public void Damage(int damageNum, PlayerManager manager)
    {
        hp -= damageNum;
        if (hp > 0)
        {
            //deathˆ—
        }
    }

    public int FlagGuide => flagGuide;
    public int FlagMark => flagMark;
    public int FlagLight => flagLight;
    public void UpdateFlag(FragmentType fragmentType)
    {
        switch (fragmentType)
        {
            case FragmentType.Guide:
                flagGuide += calcFlagment;
                //Debug.Log($"flagGuide += {calcFlagment}, {flagGuide}");
                break;
            case FragmentType.Mark:
                flagMark += calcFlagment;
                //Debug.Log($"flagMark += {calcFlagment}, {flagMark}");
                break;
            case FragmentType.Light:
                flagLight += calcFlagment;
                //Debug.Log($"flagLight += {calcFlagment}, {flagLight}");
                break;
        }

        if(flagGuide < 0)
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPaused = true;
#endif
            throw new ArgumentOutOfRangeException(nameof(flagGuide), "GuideFlagment ‚ÌŠŽ”‚ª0‚ð‰º‰ñ‚è‚Ü‚µ‚½");
        }

        if (flagMark < 0)
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPaused = true;
#endif
            throw new ArgumentOutOfRangeException(nameof(flagMark), "MarkFlagment ‚ÌŠŽ”‚ª0‚ð‰º‰ñ‚è‚Ü‚µ‚½");
        }

        if (flagLight < 0)
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPaused = true;
#endif
            throw new ArgumentOutOfRangeException(nameof(flagMark), "LightFlagment ‚ÌŠŽ”‚ª0‚ð‰º‰ñ‚è‚Ü‚µ‚½");
        }
    }
}
