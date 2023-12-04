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

    /// <summary> y軸の上方向の最大 </summary>
    public float MinAngleY { get => m_CameraSettings.upperAngleY; }
    /// <summary> y軸の下方向の最大 </summary>
    public float MaxAngleY { get => m_CameraSettings.lowerAngleY; }
    /// <summary> y軸の上方向の最大 </summary>
    public Quaternion UpperQ { get => Quaternion.Euler(MinAngleY, 0, 0); }
    /// <summary> y軸の下方向の最大 </summary>
    public Quaternion LowerQ { get => Quaternion.Euler(MaxAngleY, 0, 0); }
}

[Serializable]
public struct PlayerDefaultStatus
{
    //体力
    public int hp;
    //攻撃力
    public int power;
    //歩く速度
    public float walkSpeed;
    //走る速度
    public float sprintSpeed;
    //ジャンプする高さ
    public float jumpHeight;
    //加速度の最大値
    public float maxAcceleration;
    //回転速度
    public float rotateSpeed;
    //空気抵抗
    public float airControl;
}

[Serializable]
public struct CameraSettings
{
    //y軸の上方向の最大
    public float upperAngleY;
    //y軸の下方向の最大
    public float lowerAngleY;
    //カメラの回転速度
    //public float rotateSpeed;
}