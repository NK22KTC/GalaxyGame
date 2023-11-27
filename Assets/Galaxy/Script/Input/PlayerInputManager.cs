using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager
{
    private Key key = new Key();
    private Mouse mouse = new Mouse();

    public Key m_Key => key;
    public Mouse m_Mouse => mouse;
}