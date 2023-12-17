
public interface IActorStatus
{
    public int m_Hp { get; }
    public int m_Power { get; }
}

public interface IHitPointHandler
{
    void Heal(int healNum);
    void Damage(int damageNum);
}

public interface IStateHander
{
    void Death();
    void Respawn();
}

public interface IActors
{
    IActorStatus m_ActorStatus { get; }
    IHitPointHandler m_HitPointHandler { get; }
}
