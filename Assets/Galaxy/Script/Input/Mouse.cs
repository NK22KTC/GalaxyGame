using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MouseButtonType
{
    Left,
    Right,
    Wheel
}

public class MouseButton
{
    private readonly int mouseNum;
    public int m_MouseNum => mouseNum;

    public static List<MouseButton> m_MouseList = new List<MouseButton>();

    private MouseButton() { }

    public MouseButton(int mouseNum)
    {
        this.mouseNum = mouseNum;
    }

public static readonly MouseButton Attack = new MouseButton(0);
public static readonly MouseButton MouseRight = new MouseButton(1);
public static readonly MouseButton MouseWheel = new MouseButton(2);
}
