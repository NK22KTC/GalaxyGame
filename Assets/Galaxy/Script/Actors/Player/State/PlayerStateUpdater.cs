
using UnityEngine;

public static class PlayerStateUpdater
{
    /// <summary> 5番目に処理</summary>
    public static PlayerMoveState UpdateMoveState(PlayerStatePresenter m_StateManager)
    {
        return !m_StateManager.canOperate ? PlayerMoveState.Idle :
                       //m_StateManager.isRespawning ? PlayerMoveState.Respawning :
                       //m_StateManager.isDead ? PlayerMoveState.Death :
                       //m_StateManager.isWarping ? PlayerMoveState.Warping :
                       !m_StateManager.isGrounded || PlayerInputPresenter.HoldJump ? PlayerMoveState.Jump :
                       PlayerInputPresenter.isSprint ? PlayerMoveState.Run :
                       PlayerInputPresenter.isWalk ? PlayerMoveState.Walk :
                       PlayerMoveState.Idle;
    }

    private static PlayerAttackState UpdateAttackState(PlayerStatePresenter m_StateManager)
    {
        return PlayerInputPresenter.SwitchAttack ? PlayerAttackState.Attack : PlayerAttackState.Idle;
    }

    /// <summary> 3or4番目に処理</summary>
    private static PlayerPickState UpdatePickState(PlayerStatePresenter m_StateManager)
    {
        return m_StateManager.isPickUping ? PlayerPickState.Picking : PlayerPickState.UnPicking;
    }

    /// <summary> 3or4番目に処理</summary>
    private static PlayerGroundState UpdateGroundState(PlayerStatePresenter m_StateManager)
    {
        return m_StateManager.isGrounded ? PlayerGroundState.Grounded : PlayerGroundState.UnGrounded;
    }

    /// <summary> 2番目に処理</summary>
    private static PlayerGameState UpdateGameState(PlayerStatePresenter m_StateManager)
    {
        return m_StateManager.isOperating ? PlayerGameState.Operating : PlayerGameState.OpeningMenu;
    }

    /// <summary> 1番目に処理</summary>
    private static PlayerProgressState UpdateProgressState(PlayerStatePresenter m_StateManager)
    {
        return m_StateManager.isPlayingGame ? PlayerProgressState.PlayingGame :
               m_StateManager.isGameClear ? PlayerProgressState.GameClear :
                                            PlayerProgressState.GameOver;
    }

    //ステート更新はここから
    public static PlayerStatePresenter ChangeState(PlayerStatePresenter m_StateManager)
    {
        m_StateManager.ChangeProgressState( UpdateProgressState(m_StateManager) );
        m_StateManager.ChangeGameState( UpdateGameState(m_StateManager) );
        m_StateManager.ChangePickState( UpdatePickState(m_StateManager) );
        m_StateManager.ChangeGroundState( UpdateGroundState(m_StateManager) );
        m_StateManager.ChangeAttackState(UpdateAttackState(m_StateManager));
        m_StateManager.ChangeMoveState( UpdateMoveState(m_StateManager) );
        return m_StateManager;
    }
}
