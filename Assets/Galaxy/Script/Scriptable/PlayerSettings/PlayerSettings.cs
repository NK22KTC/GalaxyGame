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

    /// <summary> プレイヤーの体力 </summary>
    public int Hp => m_PlayerDefaultStatus.hp;
    /// <summary> プレイヤーの攻撃力 </summary>
    public int Power => m_PlayerDefaultStatus.power;
    /// <summary> プレイヤーの歩く速度 </summary>
    public float WalkSpeed => m_PlayerDefaultStatus.walkSpeed;
    /// <summary> プレイヤーの走る速度 </summary>
    public float SprintSpeed => m_PlayerDefaultStatus.sprintSpeed;
    /// <summary> プレイヤーのジャンプ力 </summary>
    public float JumpHeight => m_PlayerDefaultStatus.jumpHeight;
    /// <summary> プレイヤーの速度の最大値(?) </summary>
    public float MaxAcceleration => m_PlayerDefaultStatus.maxAcceleration;
    /// <summary> プレイヤーの回転速度 </summary>
    public float RotateSpeed => m_PlayerDefaultStatus.rotateSpeed;
    /// <summary> プレイヤーの空気抵抗(?) </summary>
    public float AirControl => m_PlayerDefaultStatus.airControl;
    /// <summary> プレイヤーが取得できるアイテムの最大距離 </summary>
    public float ObtainableDistance => m_PlayerDefaultStatus.obtainableDistance;

    /// <summary> y軸の上方向の最大 </summary>
    public float MinAngleY => m_CameraSettings.upperAngleY;
    /// <summary> y軸の下方向の最大 </summary>
    public float MaxAngleY => m_CameraSettings.lowerAngleY;
    /// <summary> y軸の上方向の最大 </summary>
    public Quaternion UpperQ => Quaternion.Euler(MinAngleY, 0, 0);
    /// <summary> y軸の下方向の最大 </summary>
    public Quaternion LowerQ => Quaternion.Euler(MaxAngleY, 0, 0);
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
    //アイテムを取得できる距離
    public float obtainableDistance;
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