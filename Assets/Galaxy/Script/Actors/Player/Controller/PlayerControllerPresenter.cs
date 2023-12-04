using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerPresenter
{
    private PlayerControllerManager m_PlayerController;
    
    public PlayerControllerPresenter(Transform playerTransform, Transform cameraTransform)
    {
        m_PlayerController = new PlayerControllerManager(playerTransform, cameraTransform);
    }

    //public void Move(Rigidbody rb, PlayerManager m_PlayerManager, Vector3 input) => LocomotionCalculator.CalcMovement(rb, m_PlayerManager, input);

    //public void
}
