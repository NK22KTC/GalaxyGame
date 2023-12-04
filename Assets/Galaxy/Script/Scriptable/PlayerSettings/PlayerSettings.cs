using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSettings", menuName = "ScriptableObjects/Create PlayerSettings")]
public class PlayerSettings : ScriptableObject, IActorStatus
{
    [SerializeField]
    PlayerDefaultStatus m_PlayerDefaultStatus;

    [SerializeField]
    CameraSettings m_CameraSettings;

    public int Hp { get => m_PlayerDefaultStatus.hp; }
    public int Power { get => m_PlayerDefaultStatus.power; }
    public float WalkSpeed { get => m_PlayerDefaultStatus.walkSpeed; }
    public float SprintSpeed { get => m_PlayerDefaultStatus.sprintSpeed; }
    public float JumpHeight { get => m_PlayerDefaultStatus.jumpHeight; }
    public float MaxAcceleration { get => m_PlayerDefaultStatus.maxAcceleration; }
    public float RotateSpeed { get => m_PlayerDefaultStatus.rotateSpeed; }
    public float AirControl { get => m_PlayerDefaultStatus.airControl; }

    /// <summary> y���̏�����̍ő� </summary>
    public float MinAngleY { get => m_CameraSettings.upperAngleY; }
    /// <summary> y���̉������̍ő� </summary>
    public float MaxAngleY { get => m_CameraSettings.lowerAngleY; }
    /// <summary> y���̏�����̍ő� </summary>
    public Quaternion UpperQ { get => Quaternion.Euler(MinAngleY, 0, 0); }
    /// <summary> y���̉������̍ő� </summary>
    public Quaternion LowerQ { get => Quaternion.Euler(MaxAngleY, 0, 0); }
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