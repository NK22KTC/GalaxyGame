using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSettings", menuName = "ScriptableObjects/Create PlayerSettings")]
public class PlayerSettings : ScriptableObject
{
    [SerializeField]
    PlayerDefaultStatus m_PlayerDefaultStatus;

    [SerializeField]
    CameraSettings m_CameraSettings;

    /// <summary> �v���C���[�̗̑� </summary>
    public int Hp => m_PlayerDefaultStatus.hp;
    /// <summary> �v���C���[�̍U���� </summary>
    public int Power => m_PlayerDefaultStatus.power;
    /// <summary> �v���C���[�̕������x </summary>
    public float WalkSpeed => m_PlayerDefaultStatus.walkSpeed;
    /// <summary> �v���C���[�̑��鑬�x </summary>
    public float SprintSpeed => m_PlayerDefaultStatus.sprintSpeed;
    /// <summary> �v���C���[�̃W�����v�� </summary>
    public float JumpHeight => m_PlayerDefaultStatus.jumpHeight;
    /// <summary> �v���C���[�̑��x�̍ő�l(?) </summary>
    public float MaxAcceleration => m_PlayerDefaultStatus.maxAcceleration;
    /// <summary> �v���C���[�̉�]���x </summary>
    public float RotateSpeed => m_PlayerDefaultStatus.rotateSpeed;
    /// <summary> �v���C���[�̋�C��R(?) </summary>
    public float AirControl => m_PlayerDefaultStatus.airControl;
    /// <summary> �v���C���[���擾�ł���A�C�e���̍ő勗�� </summary>
    public float ObtainableDistance => m_PlayerDefaultStatus.obtainableDistance;

    /// <summary> y���̏�����̍ő� </summary>
    public float MinAngleY => m_CameraSettings.upperAngleY;
    /// <summary> y���̉������̍ő� </summary>
    public float MaxAngleY => m_CameraSettings.lowerAngleY;
    /// <summary> y���̏�����̍ő� </summary>
    public Quaternion UpperQ => Quaternion.Euler(MinAngleY, 0, 0);
    /// <summary> y���̉������̍ő� </summary>
    public Quaternion LowerQ => Quaternion.Euler(MaxAngleY, 0, 0);
}

[Serializable]
public struct PlayerDefaultStatus
{
    //�̗�
    public int hp;
    //�U����
    public int power;
    //�������x
    public float walkSpeed;
    //���鑬�x
    public float sprintSpeed;
    //�W�����v���鍂��
    public float jumpHeight;
    //�����x�̍ő�l
    public float maxAcceleration;
    //��]���x
    public float rotateSpeed;
    //��C��R
    public float airControl;
    //�A�C�e�����擾�ł��鋗��
    public float obtainableDistance;
}

[Serializable]
public struct CameraSettings
{
    //y���̏�����̍ő�
    public float upperAngleY;
    //y���̉������̍ő�
    public float lowerAngleY;
    //�J�����̉�]���x
    //public float rotateSpeed;
}