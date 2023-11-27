using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerStatePresenter m_StateManager;
    PlayerInputPresenter m_InputPresenter;

    Rigidbody rb;

    //プレイヤーの回転する向き
    //1 -> （プレイヤーから見て）時計回り
    //-1 -> （プレイヤーから見て）反時計回り
    private float rotate_direction = 0;

    private void Init()
    {
        PlayerManager playerManager = GetComponent<PlayerManager>();

        m_StateManager = playerManager.m_StatePresenter;
        m_InputPresenter = playerManager.m_InputPresenter;
    }

    void Start()
    {
        Init();

        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Jump();
    }

    private void LateUpdate()
    {
        Horizontal_Rotate();

        Move();
    }

    public void Move()
    {
        if (!m_StateManager.canMove) return;

        Vector3 move_direction = m_InputPresenter.Move.normalized;
        float moveSpeed = m_InputPresenter.HoldSprint ? GeneralSettings.Instance.m_PlayerSettings.SprintSpeed : GeneralSettings.Instance.m_PlayerSettings.WalkSpeed;

        rb.MovePosition(rb.position + transform.TransformDirection(move_direction) * moveSpeed * Time.deltaTime);
    }

    public void Jump()
    {
        if (!m_StateManager.canJump) return;

        if (m_InputPresenter.HoldJump)//  もし、スペースキーがおされたなら、  
        {
            Debug.Log("Jumped");
            rb.AddForce(transform.up * GeneralSettings.Instance.m_PlayerSettings.JumpPower * 100);//  上にJumpPower分力をかける
            m_StateManager.ChangeGroundState(PlayerGroundState.UnGrounded);
        }
    }

    void OnCollisionEnter(Collision other)//  床オブジェクトに触れた時の処理
    {
        if (other.transform.GetComponent<IGroundable>() == null) return;

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

        rotate_direction = m_InputPresenter.Rotate.x;

        // オブジェクトからみて垂直方向を軸として回転させるQuaternionを作成
        Quaternion rot = Quaternion.AngleAxis(rotate_direction * GeneralSettings.Instance.m_PlayerSettings.RotateSpeed, transform.up);
        // 現在の自信の回転の情報を取得する。
        Quaternion q = transform.rotation;
        // 合成して、自身に設定
        transform.rotation = rot * q;
    }
}