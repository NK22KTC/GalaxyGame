
public interface IActorStatus
{
    public int Hp { get; }
    public int Power { get; }
}

public interface IDamagable
{
    void Damage();
    void Death();
}

public interface IRespawnable
{
    void Respawn();
}
