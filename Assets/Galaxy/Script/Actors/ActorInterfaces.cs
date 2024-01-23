
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

/// <summary> ���̃C���^�[�t�F�[�X�̓v���C���[�ƓG�̃C���^�[�t�F�[�X�p���p�ł��B�ȉ��̃C���^�[�t�F�[�X���g�p���Ă��������B </summary>
/// <remarks> Player : <see cref="IPlayer"/>
/// Enemy : <see cref="IEnemy"/></remarks>
[System.Obsolete]  //�����񐄏��̏d�v�x�̍\����ύX���Ă��܂�����v���W�F�N�g����.editorconfig�t�@�C���́@dotnet_diagnostic.CS0612.severity �� warning�ɕύX����
public interface IActors
{
    IActorStatus m_ActorStatus { get; }
    IHitPointHandler m_HitPointHandler { get; }
}

#pragma warning disable CS0612 // �^�܂��̓����o�[�����^���ł�
public interface IPlayer : IActors
#pragma warning restore CS0612 // �^�܂��̓����o�[�����^���ł�
{

}

#pragma warning disable CS0612 // �^�܂��̓����o�[�����^���ł�
public interface IEnemy : IActors
#pragma warning restore CS0612 // �^�܂��̓����o�[�����^���ł�
{
    void GetGroundInfo(GroundManager GroundManager);
}
