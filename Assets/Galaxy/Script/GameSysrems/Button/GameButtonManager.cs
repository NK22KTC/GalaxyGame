using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameButtonManager
{
    private Transform button;
    private GameManager gameManager => MonoBehaviour.FindObjectOfType<GameManager>();
    bool isPushed = false;
    public bool IsPushed => isPushed;

    [PunRPC]
    void UpdateClearCondion(PhotonView view) => gameManager.m_IGameClearCondion.UpdateClearCondion(view, true);

    internal GameButtonManager(Transform buttonTransform)
    {
        button = buttonTransform;
    }

    public void ChangePushState(PhotonView view)
    {
        if (isPushed) { return; }
        isPushed = true;
        button.position = new Vector3(button.position.x, button.position.y - 0.07f, button.position.z);

        gameManager.m_View.RPC(nameof(UpdateClearCondion), RpcTarget.AllBuffered, view);
    }
}