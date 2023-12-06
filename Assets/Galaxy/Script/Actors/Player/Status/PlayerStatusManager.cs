using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusManager
{
    private int hp;
    public int calcHp;

    private int flagGuide = 0;
    private int flagMark = 0;
    private int flagLight = 0;
    public int calcFlagment;

    public int Hp => hp;
    public void UpdateHp()
    {
        hp += calcHp;
        if(hp < 0)
        {
            hp = 0;
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
