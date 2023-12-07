
public class PlayerStatePresenter
{
    PlayerStateManager StateManager = new PlayerStateManager();

    //Disabled�̃X�e�[�g�����邩�ǂ���
    public bool isDisabled => StateManager.MoveState == PlayerMoveState.Disabled ||
                              StateManager.PickState == PlayerPickState.Disabled ||
                              StateManager.GroundState == PlayerGroundState.Disabled ||
                              StateManager.GameState == PlayerGameState.Disabled ||
                              StateManager.ProgressState == PlayerProgressState.Disabled;

    //�L�����N�^�[�𑀍�ł��邩�ǂ���
    public bool canOperate => !isDisabled && !isDead && !isRespawning && !isOpeningMenu && !isGameClear && !isGameOver && isOperating;  //�Ō��PlayerGameState��Operating���ǂ���

    //------------------------------------------PlayerActionState------------------------------------------------------

    //�����Ă��邩�ǂ���
    public bool isWalking => StateManager.MoveState == PlayerMoveState.Walk;

    //�����Ă��邩�ǂ���
    public bool isRunning => StateManager.MoveState == PlayerMoveState.Run;

    //�W�����v�����ǂ���
    public bool isJumping => StateManager.MoveState == PlayerMoveState.Jump;

    //�U�������ǂ���
    public bool isAttacking => StateManager.MoveState == PlayerMoveState.Attack;

    //���[�v�����ǂ���
    public bool isWarping => StateManager.MoveState == PlayerMoveState.Warping;

    //���S�����ǂ���
    public bool isDead => StateManager.MoveState == PlayerMoveState.Death;

    //���X�|�[�������ǂ���
    public bool isRespawning => StateManager.MoveState == PlayerMoveState.Respawning;



    //�ړ����ł��邩(�L�����𑀍�ł��� && ���[�v���łȂ�)
    public bool canMove => canOperate && !isWarping;

    //���_�ړ����ł��邩(�L�����𑀍�ł���)
    public bool canLook => canOperate;

    //�U���ł��邩(�L�����𑀍�ł��� && ���[�v���łȂ� && �A�C�e�����E���Ă��Ȃ�)
    public bool canAttack => canOperate && !isWarping && isPickUping;

    //�W�����v�ł��邩 (�L�����𑀍�ł��� && �ڒn���Ă���)
    public bool canJump => canOperate && !isWarping && StateManager.GroundState == PlayerGroundState.Grounded;

    //�����ňړ��X�e�[�g�̏�Ԃ��㏑������
    public void ChangeMoveState(PlayerMoveState newstate) => StateManager.ChangeMoveState(newstate);

    //----------------------------------------------------------------------------------------------------------------

    //------------------------------------PlayerPickState-------------------------------------------------------------

    //�A�C�e�����E���Ă��邩�r�����ǂ���
    public bool isPickUping => StateManager.PickState == PlayerPickState.Picking;

    //�A�C�e�����E���邩(�L�����𑀍�ł��� && ���[�v���łȂ� && �U�����łȂ�)
    public bool canPickUp => canOperate && !isWarping && !isAttacking && !isJumping;

    public void ChangePickState(PlayerPickState newState) => StateManager.ChangePickState(newState);

    //------------------------------------PlayerGroundState-----------------------------------------------------------

    //�L�����N�^�[���ڒn���Ă��邩�ǂ���
    public bool isGrounded => StateManager.GroundState == PlayerGroundState.Grounded;

    //�����Őڒn�X�e�[�g�̏�Ԃ��㏑������
    public void ChangeGroundState(PlayerGroundState newstate) => StateManager.ChangeGroundState(newstate);

    //----------------------------------------------------------------------------------------------------------------

    //------------------------------------PlayerGameState-------------------------------------------------------------

    //�L�����𑀍삷���Ԃ��ǂ���
    public bool isOperating => StateManager.GameState == PlayerGameState.Operating;

    //���j���[���J���Ă��邩�ǂ���
    public bool isOpeningMenu => StateManager.GameState == PlayerGameState.OpeningMenu;

    //�����ŃQ�[���X�e�[�g�̏�Ԃ��㏑������
    public void ChangeGameState(PlayerGameState newstate) => StateManager.ChangeGameState(newstate);

    //----------------------------------------------------------------------------------------------------------------

    //------------------------------------PlayerProgressState---------------------------------------------------------

    //�Q�[���i�s�����ǂ���
    public bool isPlayingGame => StateManager.ProgressState == PlayerProgressState.PlayingGame;

    //�Q�[�����N���A������
    public bool isGameClear => StateManager.ProgressState == PlayerProgressState.GameClear;

    //�Q�[���I�[�o�[�ɂȂ�����
    public bool isGameOver => StateManager.ProgressState == PlayerProgressState.GameOver;

    public void ChangeProgressState(PlayerProgressState newState) => StateManager.ChangeProgressState(newState);

    //----------------------------------------------------------------------------------------------------------------

    public void OnStartPlayState()
    {
        ChangeMoveState(PlayerMoveState.Idle);
        ChangePickState(PlayerPickState.UnPicking);
        ChangeGroundState(PlayerGroundState.UnGrounded);
        ChangeGameState(PlayerGameState.Operating);
        ChangeProgressState(PlayerProgressState.PlayingGame);
    }
}
