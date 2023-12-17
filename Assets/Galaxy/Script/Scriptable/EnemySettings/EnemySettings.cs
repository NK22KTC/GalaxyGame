using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySettings", menuName = "ScriptableObjects/Create EnemySettings")]
public class EnemySettings : ScriptableObject
{
    //‘Ì—Í
    [SerializeField]
    int hp;
    //UŒ‚—Í
    [SerializeField]
    int power;
    //•à‚­‘¬“x
    [SerializeField]
    float walkSpeed;

    public int Hp { get => hp; }
    public int Power { get => power; }
    public float WalkSpeed { get => walkSpeed; }
}
