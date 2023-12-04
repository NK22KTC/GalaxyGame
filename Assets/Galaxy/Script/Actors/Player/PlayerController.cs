using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerManager playerManager;

    PlayerStatePresenter m_StateManager;

    Rigidbody rb;

    Vector3 moveDuringJump;  //�W�����v���̈ړ�����(�W�����v�����u�Ԃ̈ړ��������i�[)

    //�v���C���[�̉�]�������
    //1 -> �i�v���C���[���猩�āj���v���
    //-1 -> �i�v���C���[���猩�āj�����v���
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

        if (PlayerInputPresenter.HoldJump)//  �����A�W�����v�L�[�������ꂽ�Ȃ�A
        {
            moveDuringJump = rb.velocity;
            Debug.Log("Jumped");
            rb.AddForce(Vector3.up * GeneralSettings.Instance.m_PlayerSettings.JumpHeight, ForceMode.VelocityChange);
            //LocomotionCalculator.CalcJump(rb);
            m_StateManager.ChangeGroundState(PlayerGroundState.UnGrounded);
        }
    }

    void OnCollisionStay(Collision other)//  ���I�u�W�F�N�g�ɐG�ꂽ���̏���
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

        // �I�u�W�F�N�g����݂Đ������������Ƃ��ĉ�]������Quaternion���쐬
        Quaternion rot = Quaternion.AngleAxis(rotate_direction * GeneralSettings.Instance.m_PlayerSettings.RotateSpeed, transform.up);
        // ���݂̎��M�̉�]�̏����擾����B
        Quaternion q = transform.rotation;
        // �������āA���g�ɐݒ�
        transform.rotation = rot * q;
    }
}