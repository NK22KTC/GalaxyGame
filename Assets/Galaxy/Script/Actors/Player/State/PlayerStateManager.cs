
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
    /// <summary>�U��</summary>
    Attack,
    /// <summary>�����ړ���</summary>
    Warping,
    /// <summary>��</summary>
    Death,
    /// <summary>���X�|�[����</summary>
    Respawning
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
    private PlayerPickState pickState = PlayerPickState.Disabled;
    private PlayerGroundState groundState = PlayerGroundState.Disabled;
    private PlayerGameState gameState = PlayerGameState.Disabled;
    private PlayerProgressState progressState = PlayerProgressState.Disabled;

    public PlayerMoveState MoveState { get => moveState; }
    public void ChangeMoveState(PlayerMoveState newstate) => moveState = newstate;
    public PlayerPickState PickState { get => pickState; }
    public void ChangePickState(PlayerPickState newState) => pickState = newState;
    public PlayerGroundState GroundState { get => groundState; }
    public void ChangeGroundState(PlayerGroundState newstate) => groundState = newstate;
    public PlayerGameState GameState { get => gameState; }
    public void ChangeGameState(PlayerGameState newstate) => gameState = newstate;
    public PlayerProgressState ProgressState { get => progressState; }
    public void ChangeProgressState(PlayerProgressState newState) => progressState = newState;
}