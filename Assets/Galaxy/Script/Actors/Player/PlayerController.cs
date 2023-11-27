using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerStatePresenter m_StateManager;
    PlayerInputPresenter m_InputPresenter;

    Rigidbody rb;

    //�v���C���[�̉�]�������
    //1 -> �i�v���C���[���猩�āj���v���
    //-1 -> �i�v���C���[���猩�āj�����v���
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

        if (m_InputPresenter.HoldJump)//  �����A�X�y�[�X�L�[�������ꂽ�Ȃ�A  
        {
            Debug.Log("Jumped");
            rb.AddForce(transform.up * GeneralSettings.Instance.m_PlayerSettings.JumpPower * 100);//  ���JumpPower���͂�������
            m_StateManager.ChangeGroundState(PlayerGroundState.UnGrounded);
        }
    }

    void OnCollisionEnter(Collision other)//  ���I�u�W�F�N�g�ɐG�ꂽ���̏���
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

        // �I�u�W�F�N�g����݂Đ������������Ƃ��ĉ�]������Quaternion���쐬
        Quaternion rot = Quaternion.AngleAxis(rotate_direction * GeneralSettings.Instance.m_PlayerSettings.RotateSpeed, transform.up);
        // ���݂̎��M�̉�]�̏����擾����B
        Quaternion q = transform.rotation;
        // �������āA���g�ɐݒ�
        transform.rotation = rot * q;
    }
}