using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerInputPresenter
{
    //private PlayerInputManager InputManager = new PlayerInputManager();

    //前後キーを同時に押すと移動しない、左右キーも同様
    public static float MoveRightVec => (Input.GetKey(Key.Right.m_KeyCode) ? 1 : 0) - (Input.GetKey(Key.Left.m_KeyCode) ? 1 : 0);
    public static float MoveForwardVec => (Input.GetKey(Key.Forward.m_KeyCode) ? 1 : 0) - (Input.GetKey(Key.Backward.m_KeyCode) ? 1 : 0);
    public static Vector3 Move => new Vector3(MoveRightVec, 0, MoveForwardVec);

    public static bool SwitchSprint => Input.GetKeyDown(Key.Sprint.m_KeyCode);
    public static bool SwitchJump => Input.GetKeyDown(Key.Jump.m_KeyCode);
    public static bool SwitchGetItem => Input.GetKeyDown(Key.GetItem.m_KeyCode);
    public static bool SwitchTeleport => Input.GetKeyDown(Key.Teleport.m_KeyCode);
    public static bool SwitchMenu => Input.GetKeyDown(Key.Menu.m_KeyCode);

    public static bool HoldSprint => Input.GetKey(Key.Sprint.m_KeyCode);
    public static bool HoldJump => Input.GetKey(Key.Jump.m_KeyCode);
    public static bool HoldGetItem => Input.GetKey(Key.GetItem.m_KeyCode);
    //public bool HoldTeleport => Input.GetKey(InputManager.m_Key.Teleport);
    //public bool HoldMenu => Input.GetKey(key.Menu);

    public static bool isWalk => Move.magnitude > 0;
    public static bool isSprint => isWalk && HoldSprint;


    public static Vector2 Rotate => new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
    public static bool SwitchAttack => Input.GetMouseButtonDown(MouseButton.Attack.m_MouseNum);
}
