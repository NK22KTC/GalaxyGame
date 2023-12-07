using UnityEngine;

public class PlayerControllerPresenter
{
    private PlayerControllerManager m_PlayerController;
    
    public PlayerControllerPresenter(Transform playerTransform, Transform cameraTransform)
    {
        m_PlayerController = new PlayerControllerManager(playerTransform, cameraTransform);
    }
}
