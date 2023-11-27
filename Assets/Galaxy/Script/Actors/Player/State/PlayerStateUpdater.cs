using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public static class PlayerStateUpdater
{
    /// <summary> 5番目に処理</summary>
    public static PlayerMoveState UpdateMoveState(PlayerStatePresenter m_StateManager, PlayerInputPresenter m_InputPresenter)
    {
        var newMoveState = !m_StateManager.canOperate ? PlayerMoveState.Idle :
                       //m_StateManager.isRespawning ? PlayerMoveState.Respawning :
                       //m_StateManager.isDead ? PlayerMoveState.Death :
                       //m_StateManager.isWarping ? PlayerMoveState.Warping :
                       m_InputPresenter.SwitchAttack ? PlayerMoveState.Attack :
                       !m_StateManager.isGrounded || m_InputPresenter.HoldJump ? PlayerMoveState.Jump :
                       m_InputPresenter.isSprint ? PlayerMoveState.Run :
                       m_InputPresenter.isWalk ? PlayerMoveState.Walk :
                       PlayerMoveState.Idle;
        return newMoveState;
    }

    /// <summary> 3or4番目に処理</summary>
    private static PlayerPickState UpdatePickState(PlayerStatePresenter m_StateManager, PlayerInputPresenter m_InputPresenter)
    {
        var newPickState = m_StateManager.isPickUping ? PlayerPickState.Picking :
                    PlayerPickState.UnPicking;
        return newPickState;
    }

    /// <summary> 3or4番目に処理</summary>
    private static PlayerGroundState UpdateGroundState(PlayerStatePresenter m_StateManager, PlayerInputPresenter m_InputPresenter)
    {
        var newGroundState = m_StateManager.isGrounded ? PlayerGroundState.Grounded : PlayerGroundState.UnGrounded;
        return newGroundState;
    }

    /// <summary> 2番目に処理</summary>
    private static PlayerGameState UpdateGameState(PlayerStatePresenter m_StateManager, PlayerInputPresenter m_InputPresenter)
    {
        var newGameState = m_StateManager.isOperating ? PlayerGameState.Operating : PlayerGameState.OpeningMenu;
        return newGameState;
    }

    /// <summary> 1番目に処理</summary>
    private static PlayerProgressState UpdateProgressState(PlayerStatePresenter m_StateManager, PlayerInputPresenter m_InputPresenter)
    {
        var newProgressState = m_StateManager.isPlayingGame ? PlayerProgressState.PlayingGame :
                               m_StateManager.isGameClear ? PlayerProgressState.GameClear :
                               PlayerProgressState.GameOver;
        return newProgressState;
    }

    //ステート更新はここから
    public static PlayerStatePresenter ChangeState(PlayerStatePresenter m_StateManager, PlayerInputPresenter m_InputPresenter)
    {
        m_StateManager.ChangeProgressState( UpdateProgressState(m_StateManager, m_InputPresenter) );
        m_StateManager.ChangeGameState( UpdateGameState(m_StateManager, m_InputPresenter) );
        m_StateManager.ChangePickState( UpdatePickState(m_StateManager, m_InputPresenter) );
        m_StateManager.ChangeGroundState( UpdateGroundState(m_StateManager, m_InputPresenter) );
        m_StateManager.ChangeMoveState( UpdateMoveState(m_StateManager, m_InputPresenter) );

        return m_StateManager;
    }
}
