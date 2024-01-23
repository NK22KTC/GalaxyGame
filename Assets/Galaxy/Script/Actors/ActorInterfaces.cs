
public interface IActorStatus
{
    public int m_Hp { get; }
    public int m_Power { get; }
}

public interface IHitPointHandler
{
    void Heal(int healNum);
    void Damage(int damageNum, PlayerManager manager);
}

public interface IStateHander
{
    void Death();
    void Respawn();
}

/// <summary> このインターフェースはプレイヤーと敵のインターフェース継承用です。以下のインターフェースを使用してください。 </summary>
/// <remarks> Player : <see cref="IPlayer"/>
/// Enemy : <see cref="IEnemy"/></remarks>
[System.Obsolete]  //もし非推奨の重要度の構成を変更してしまったらプロジェクト内の.editorconfigファイルの　dotnet_diagnostic.CS0612.severity を warningに変更する
public interface IActors
{
    IActorStatus m_ActorStatus { get; }
    IHitPointHandler m_HitPointHandler { get; }
}

#pragma warning disable CS0612 // 型またはメンバーが旧型式です
public interface IPlayer : IActors
#pragma warning restore CS0612 // 型またはメンバーが旧型式です
{

}

#pragma warning disable CS0612 // 型またはメンバーが旧型式です
public interface IEnemy : IActors
#pragma warning restore CS0612 // 型またはメンバーが旧型式です
{
    void GetGroundInfo(GroundManager GroundManager);
}
