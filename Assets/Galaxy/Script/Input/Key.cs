using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key
{
    private KeyCode keyCode;
    public KeyCode m_KeyCode => keyCode;

    public static List<Key> m_KeyList = new List<Key>();

    private Key() { }

    public Key(KeyCode keyCode)
    {
        this.keyCode = keyCode;
        m_KeyList.Add(this);
    }

    public void SetNewKey(KeyCode keyCode)  //ÉLÅ[äÑÇËìñÇƒïœçX
    {
        this.keyCode = keyCode;
    }

    public static readonly Key Forward = new Key(KeyCode.W);
    public static readonly Key Left = new Key(KeyCode.A);
    public static readonly Key Backward = new Key(KeyCode.S);
    public static readonly Key Right = new Key(KeyCode.D);
    public static readonly Key Sprint = new Key(KeyCode.LeftShift);
    public static readonly Key Jump = new Key(KeyCode.Space);
    public static readonly Key GetItem = new Key(KeyCode.F);
    public static readonly Key Teleport = new Key(KeyCode.T);
    public static readonly Key Menu = new Key(KeyCode.Escape);
}
