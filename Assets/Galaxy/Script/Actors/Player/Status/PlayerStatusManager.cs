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
    public void UpdateFlagGuide()
    {
        flagGuide += calcFlagment;
        if(flagGuide < 0)
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPaused = true;
#endif
            throw new ArgumentOutOfRangeException(nameof(flagGuide), "GuideFlagment ‚ÌŠŽ”‚ª0‚ð‰º‰ñ‚è‚Ü‚µ‚½");
        }
    }
    public int FlagMark => flagMark;
    public void UpdateFlagMark()
    {
        flagMark += calcFlagment;
        if(flagMark < 0)
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPaused = true;
#endif
            throw new ArgumentOutOfRangeException(nameof(flagMark), "MarkFlagment ‚ÌŠŽ”‚ª0‚ð‰º‰ñ‚è‚Ü‚µ‚½");
        }
    }
    public int FlagLight => flagLight;
    public void UpdateFlagLight()
    {
        flagLight += calcFlagment;
        if(flagLight < 0)
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPaused = true;
#endif
            throw new ArgumentOutOfRangeException(nameof(flagMark), "LightFlagment ‚ÌŠŽ”‚ª0‚ð‰º‰ñ‚è‚Ü‚µ‚½");
        }
    }
}
