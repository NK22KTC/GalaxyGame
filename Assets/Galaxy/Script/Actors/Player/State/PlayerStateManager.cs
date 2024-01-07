
public enum PlayerMoveState
{
    /// <summary>�Q�[���J�n�̏u�Ԃ����g��</summary>
    Disabled,
    /// <summary>�����Ă��Ȃ�</summary>
    Idle,
    /// <summary>����</summary>
    Walk,
    /// <summary>����</summary>
    Run,
    /// <summary>����</summary>
    Jump,
    /// <summary>�����ړ���</summary>
    Warping,
    /// <summary>��</summary>
    Death,
    /// <summary>���X�|�[����</summary>
    Respawning
}

public enum PlayerAttackState
{
    /// <summary>�Q�[���J�n�̏u�Ԃ����g��</summary>
    Disabled,
    /// <summary>�U�����Ă��Ȃ�</summary>
    Idle,
    /// <summary>�U�����Ă���</summary>
    Attack
}

public enum PlayerPickState
{
    /// <summary>�Q�[���J�n�̏u�Ԃ����g��</summary>
    Disabled,
    /// <summary>�A�C�e�����E��</summary>
    Picking,
    /// <summary>�A�C�e�����E���Ă��Ȃ�</summary>
    UnPicking,
}

public enum PlayerGroundState
{
    /// <summary>�Q�[���J�n�̏u�Ԃ����g��</summary>
    Disabled,
    /// <summary>�ڒn���Ă���</summary>
    Grounded,
    /// <summary>�ڒn���Ă��Ȃ�</summary>
    UnGrounded,
}

public enum PlayerGameState
{
    /// <summary>�Q�[���J�n�̏u�Ԃ����g��</summary>
    Disabled,
    /// <summary>�L�������쒆</summary>
    Operating,
    /// <summary>���j���[���J���Ă���</summary>
    OpeningMenu
}

public enum PlayerProgressState
{
    /// <summary>�Q�[���J�n�̏u�Ԃ����g��</summary>
    Disabled,
    /// <summary>�Q�[���v���C��</summary>
    PlayingGame,
    /// <summary>�Q�[���N���A</summary>
    GameClear,
    /// <summary>�Q�[���I�[�o�[</summary>
    GameOver
}

public class PlayerStateManager
{
    private PlayerMoveState moveState = PlayerMoveState.Disabled;
    private PlayerAttackState attackState = PlayerAttackState.Disabled;
    private PlayerPickState pickState = PlayerPickState.Disabled;
    private PlayerGroundState groundState = PlayerGroundState.Disabled;
    private PlayerGameState gameState = PlayerGameState.Disabled;
    private PlayerProgressState progressState = PlayerProgressState.Disabled;

    public PlayerMoveState MoveState => moveState;
    public void ChangeMoveState(PlayerMoveState newstate) => moveState = newstate;
    public PlayerAttackState AttackState => attackState;
    public void ChangeAttackState(PlayerAttackState newState) => attackState = newState; 
    public PlayerPickState PickState => pickState;
    public void ChangePickState(PlayerPickState newState) => pickState = newState;
    public PlayerGroundState GroundState => groundState;
    public void ChangeGroundState(PlayerGroundState newstate) => groundState = newstate;
    public PlayerGameState GameState => gameState;
    public void ChangeGameState(PlayerGameState newstate) => gameState = newstate;
    public PlayerProgressState ProgressState => progressState;
    public void ChangeProgressState(PlayerProgressState newState) => progressState = newState;
}