using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key
{
    private KeyCode moveForward = KeyCode.W;
    private KeyCode moveLeft = KeyCode.A;
    private KeyCode moveBehind = KeyCode.S;
    private KeyCode moveRight = KeyCode.D;
    private KeyCode sprint = KeyCode.LeftShift;
    private KeyCode jump = KeyCode.Space;
    private KeyCode getItem = KeyCode.F;
    private KeyCode teleport = KeyCode.T;
    private KeyCode menu = KeyCode.Escape;


    public KeyCode MoveForward { get => moveForward; }
    public KeyCode MoveLeft { get => moveLeft; }
    public KeyCode MoveBehind { get => moveBehind; }
    public KeyCode MoveRight { get => moveRight; }
    public KeyCode Sprint { get => sprint; }
    public KeyCode Jump { get => jump; }
    public KeyCode GetItem { get => getItem; }
    public KeyCode Teleport { get => teleport; }
    public KeyCode Menu { get => menu; }
}
