using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerManager playerManager;

    PlayerStatePresenter m_StateManager;

    Rigidbody rb;

    Vector3 moveDuringJump;  //ジャンプ中の移動方向(ジャンプした瞬間の移動方向を格納)

    //プレイヤーの回転する向き
    //1 -> （プレイヤーから見て）時計回り
    //-1 -> （プレイヤーから見て）反時計回り
    private float rotate_direction = 0;

    private void Init()
    {
        playerManager = GetComponent<PlayerManager>();
        m_StateManager = playerManager.m_StatePresenter;
    }

    void Start()
    {
        Init();

        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (m_StateManager.canJump) Jump();
    }

    private void LateUpdate()
    {
        transform.rotation = LocomotionCalculator.CalcHorizontalRotate(PlayerInputPresenter.Rotate.x, transform);
        var movedir = LocomotionCalculator.CalcPlayerMovement(rb, playerManager, PlayerInputPresenter.Move);
        //rb.AddForce(movedir, ForceMode.VelocityChange);
        Move();
    }

    public void Move()
    {
        if (!m_StateManager.canMove) return;

        Vector3 move_direction = PlayerInputPresenter.Move.normalized;
        float moveSpeed = PlayerInputPresenter.HoldSprint ? GeneralSettings.Instance.m_PlayerSettings.SprintSpeed : GeneralSettings.Instance.m_PlayerSettings.WalkSpeed;

        //rb.AddForce(transform.TransformDirection(move_direction) * moveSpeed * Time.deltaTime * 50, ForceMode.Acceleration);
        rb.MovePosition(rb.position + transform.TransformDirection(move_direction) * moveSpeed * Time.deltaTime);
    }

    public void Jump()
    {
        //if (!m_StateManager.canJump) return;

        if (PlayerInputPresenter.HoldJump)//  もし、ジャンプキーがおされたなら、
        {
            moveDuringJump = rb.velocity;
            Debug.Log("Jumped");
            rb.AddForce(Vector3.up * GeneralSettings.Instance.m_PlayerSettings.JumpHeight, ForceMode.VelocityChange);
            //LocomotionCalculator.CalcJump(rb);
            m_StateManager.ChangeGroundState(PlayerGroundState.UnGrounded);
        }
    }

    void OnCollisionStay(Collision other)//  床オブジェクトに触れた時の処理
    {
        if (!other.transform.TryGetComponent(out IGroundGimmick ground)) return;

        if (m_StateManager == null) return;

        m_StateManager.ChangeGroundState(PlayerGroundState.Grounded);
    }

    
    //private void OnCollisionExit(Collision other)
    //{
    //    if (other.transform.GetComponent<IGroundable>() == null) return;

    //    m_StateManager.ChangeGroundState(PlayerGroundState.UnGrounded);
    //}

    public void Horizontal_Rotate()
    {
        if (!m_StateManager.canLook) return;

        rotate_direction = PlayerInputPresenter.Rotate.x;

        // オブジェクトからみて垂直方向を軸として回転させるQuaternionを作成
        Quaternion rot = Quaternion.AngleAxis(rotate_direction * GeneralSettings.Instance.m_PlayerSettings.RotateSpeed, transform.up);
        // 現在の自信の回転の情報を取得する。
        Quaternion q = transform.rotation;
        // 合成して、自身に設定
        transform.rotation = rot * q;
    }
}