using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputPresenter : MonoBehaviour
{
    private PlayerInputManager InputManager = new PlayerInputManager();

    //前後キーを同時に押すと移動しない、左右キーも同様
    public float MoveRightVec => (Input.GetKey(InputManager.m_Key.MoveRight) ? 1 : 0) - (Input.GetKey(InputManager.m_Key.MoveLeft) ? 1 : 0);
    public float MoveForwardVec => (Input.GetKey(InputManager.m_Key.MoveForward) ? 1 : 0) - (Input.GetKey(InputManager.m_Key.MoveBehind) ? 1 : 0);
    public Vector3 Move => new Vector3(MoveRightVec, 0, MoveForwardVec);

    public bool SwitchSprint => Input.GetKeyDown(InputManager.m_Key.Sprint);
    public bool SwitchJump => Input.GetKeyDown(InputManager.m_Key.Jump);
    public bool SwitchGetItem => Input.GetKeyDown(InputManager.m_Key.GetItem);
    public bool SwitchTeleport => Input.GetKeyDown(InputManager.m_Key.Teleport);
    public bool SwitchMenu => Input.GetKeyDown(InputManager.m_Key.Menu);

    public bool HoldSprint => Input.GetKey(InputManager.m_Key.Sprint);
    public bool HoldJump => Input.GetKey(InputManager.m_Key.Jump);
    public bool HoldGetItem => Input.GetKey(InputManager.m_Key.GetItem);
    public bool HoldTeleport => Input.GetKey(InputManager.m_Key.Teleport);
    //public bool HoldMenu => Input.GetKey(key.Menu);

    public bool isWalk => Move.magnitude > 0;
    public bool isSprint => isWalk && HoldSprint;


    public Vector2 Rotate => new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
    public bool SwitchAttack => Input.GetMouseButtonDown(InputManager.m_Mouse.Attack);
}
