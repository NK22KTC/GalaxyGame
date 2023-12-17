using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : IActors
{
    EnemyStatusManager EnemyStatusManager = new EnemyStatusManager();

    private float walkSpeed;

    public EnemyStatusManager m_EnemyStatusManager => EnemyStatusManager;

    public float WalkSpeed { get => walkSpeed; }

    public IActorStatus m_ActorStatus => EnemyStatusManager;

    public IHitPointHandler m_HitPointHandler => throw new System.NotImplementedException();
}
