using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySettings", menuName = "ScriptableObjects/Create EnemySettings")]
public class EnemySettings : ScriptableObject
{
    //�̗�
    [SerializeField]
    int hp;
    //�U����
    [SerializeField]
    int power;
    //�������x
    [SerializeField]
    float walkSpeed;

    public int Hp { get => hp; }
    public int Power { get => power; }
    public float WalkSpeed { get => walkSpeed; }
}
