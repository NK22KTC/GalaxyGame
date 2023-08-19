using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Logic : MonoBehaviour
{
    //�v���C���[�̈ړ����鑬��
    public float move_speed = 15;

    //�v���C���[�̉�]���鑬��
    public float rotate_speed = 5;

    //�v���C���[�̉�]�������
    //1 -> �i�v���C���[���猩�āj���v���
    //-1 -> �i�v���C���[���猩�āj�����v���
    private float rotate_direction = 0;

    //�v���C���[��Rigidbody
    private Rigidbody rb = null;

    //�n�ʂɒ��n���Ă��邩���肷��ϐ�
    public bool Grounded;

    //�W�����v��
    public float Jumppower;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Jump();
    }

    private void LateUpdate()
    {
        Horizontal_Rotate();

        Vector3 move_direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

        rb.MovePosition(rb.position + transform.TransformDirection(move_direction) * move_speed * Time.deltaTime);
    }

    void Jump()
    {
        if (Grounded)//  �����AGrounded��true�Ȃ�A
        {
            if (Input.GetKeyDown(KeyCode.Space))//  �����A�X�y�[�X�L�[�������ꂽ�Ȃ�A  
            {
                Grounded = false;//  Grounded��false�ɂ���
                rb.AddForce(transform.up * Jumppower * 100);//  ���JumpPower���͂�������
            }
        }
    }

    void OnCollisionEnter(Collision other)//  ���I�u�W�F�N�g�ɐG�ꂽ���̏���
    {
        if (other.gameObject.tag == "Planet")//  ����Planet�Ƃ����^�O�������I�u�W�F�N�g�ɐG�ꂽ��A
        {
            Grounded = true;//  Grounded��true�ɂ���
        }
    }

    void Horizontal_Rotate()
    {
        rotate_direction = Input.GetAxis("Mouse X");

        // �I�u�W�F�N�g����݂Đ������������Ƃ��ĉ�]������Quaternion���쐬
        Quaternion rot = Quaternion.AngleAxis(rotate_direction * rotate_speed, transform.up);
        // ���݂̎��M�̉�]�̏����擾����B
        Quaternion q = transform.rotation;
        // �������āA���g�ɐݒ�
        transform.rotation = rot * q;
    }
}