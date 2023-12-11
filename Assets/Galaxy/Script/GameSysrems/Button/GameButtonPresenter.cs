using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameButtonPresenter : MonoBehaviourPunCallbacks, IGameButton
{
    [SerializeField] 
    private Transform gameButton;
    private GameManager gameManager => FindObjectOfType<GameManager>();

    private GameButtonManager GameButtonManager;
    public GameButtonManager m_GameButtonManager => GameButtonManager;
    public bool IsPushed => GameButtonManager.IsPushed;

    private bool doingTransfer = false;
    public bool DoingTransfer => doingTransfer;

    [PunRPC] private void ChangePushState() => m_GameButtonManager.ChangePushState();
    private void UpdateClearCondion(int ViewID) => gameManager.UpdateClearCondion(ViewID);

    void Start()
    {
        GameButtonManager = new GameButtonManager(gameButton);
    }

    public void Pushing(PhotonView view)
    {
        foreach (var item in gameManager.m_IGameClearCondion.m_CleardPlayers)
        {
            if(item == view.ViewID)
            {
                return;
            }
        }

        GetComponent<PhotonView>().RPC(nameof(ChangePushState), RpcTarget.AllBuffered);
        gameManager.m_View.RPC(nameof(UpdateClearCondion), RpcTarget.AllBuffered, view.ViewID);
    }

    public PhotonView PassPhotonView()
    {
        return GetComponent<PhotonView>();
    }

    public PhotonView PassPhotonView(out PhotonView view)
    {
        return view = GetComponent<PhotonView>();
    }

    public void UpdateTransferSituation()
    {
        doingTransfer = true;
    }

}
