using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse
{
    private int mouseLeft = 0;
    private int mouseRight = 1;
    private int mouseWheel = 2;

    public int Attack { get => mouseLeft; }
    public int MouseRight { get => mouseRight; }
    public int MouseWheel { get => mouseWheel; }
}
