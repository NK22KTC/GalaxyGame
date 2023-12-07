
public class PlayerStatePresenter
{
    PlayerStateManager StateManager = new PlayerStateManager();

    //Disabledのステートがあるかどうか
    public bool isDisabled => StateManager.MoveState == PlayerMoveState.Disabled ||
                              StateManager.PickState == PlayerPickState.Disabled ||
                              StateManager.GroundState == PlayerGroundState.Disabled ||
                              StateManager.GameState == PlayerGameState.Disabled ||
                              StateManager.ProgressState == PlayerProgressState.Disabled;

    //キャラクターを操作できるかどうか
    public bool canOperate => !isDisabled && !isDead && !isRespawning && !isOpeningMenu && !isGameClear && !isGameOver && isOperating;  //最後はPlayerGameStateのOperatingかどうか

    //------------------------------------------PlayerActionState------------------------------------------------------

    //歩いているかどうか
    public bool isWalking => StateManager.MoveState == PlayerMoveState.Walk;

    //走っているかどうか
    public bool isRunning => StateManager.MoveState == PlayerMoveState.Run;

    //ジャンプ中かどうか
    public bool isJumping => StateManager.MoveState == PlayerMoveState.Jump;

    //攻撃中かどうか
    public bool isAttacking => StateManager.MoveState == PlayerMoveState.Attack;

    //ワープ中かどうか
    public bool isWarping => StateManager.MoveState == PlayerMoveState.Warping;

    //死亡中かどうか
    public bool isDead => StateManager.MoveState == PlayerMoveState.Death;

    //リスポーン中かどうか
    public bool isRespawning => StateManager.MoveState == PlayerMoveState.Respawning;



    //移動ができるか(キャラを操作できる && ワープ中でない)
    public bool canMove => canOperate && !isWarping;

    //視点移動ができるか(キャラを操作できる)
    public bool canLook => canOperate;

    //攻撃できるか(キャラを操作できる && ワープ中でない && アイテムを拾っていない)
    public bool canAttack => canOperate && !isWarping && isPickUping;

    //ジャンプできるか (キャラを操作できる && 接地している)
    public bool canJump => canOperate && !isWarping && StateManager.GroundState == PlayerGroundState.Grounded;

    //ここで移動ステートの状態を上書きする
    public void ChangeMoveState(PlayerMoveState newstate) => StateManager.ChangeMoveState(newstate);

    //----------------------------------------------------------------------------------------------------------------

    //------------------------------------PlayerPickState-------------------------------------------------------------

    //アイテムを拾っているか途中かどうか
    public bool isPickUping => StateManager.PickState == PlayerPickState.Picking;

    //アイテムを拾えるか(キャラを操作できる && ワープ中でない && 攻撃中でない)
    public bool canPickUp => canOperate && !isWarping && !isAttacking && !isJumping;

    public void ChangePickState(PlayerPickState newState) => StateManager.ChangePickState(newState);

    //------------------------------------PlayerGroundState-----------------------------------------------------------

    //キャラクターが接地しているかどうか
    public bool isGrounded => StateManager.GroundState == PlayerGroundState.Grounded;

    //ここで接地ステートの状態を上書きする
    public void ChangeGroundState(PlayerGroundState newstate) => StateManager.ChangeGroundState(newstate);

    //----------------------------------------------------------------------------------------------------------------

    //------------------------------------PlayerGameState-------------------------------------------------------------

    //キャラを操作する状態かどうか
    public bool isOperating => StateManager.GameState == PlayerGameState.Operating;

    //メニューを開いているかどうか
    public bool isOpeningMenu => StateManager.GameState == PlayerGameState.OpeningMenu;

    //ここでゲームステートの状態を上書きする
    public void ChangeGameState(PlayerGameState newstate) => StateManager.ChangeGameState(newstate);

    //----------------------------------------------------------------------------------------------------------------

    //------------------------------------PlayerProgressState---------------------------------------------------------

    //ゲーム進行中かどうか
    public bool isPlayingGame => StateManager.ProgressState == PlayerProgressState.PlayingGame;

    //ゲームをクリアしたか
    public bool isGameClear => StateManager.ProgressState == PlayerProgressState.GameClear;

    //ゲームオーバーになったか
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
