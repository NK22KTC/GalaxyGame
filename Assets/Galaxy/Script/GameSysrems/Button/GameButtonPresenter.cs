using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameButtonPresenter : MonoBehaviour, IGameButton
{
    [SerializeField] 
    private Transform gameButton;

    private bool doingTransfer = false;

    private GameButtonManager GameButtonManager;
    public GameButtonManager m_GameButtonManager => GameButtonManager;
    public bool IsPushed => GameButtonManager.IsPushed;

    public bool DoingTransfer => doingTransfer;

    void Start()
    {
        GameButtonManager = new GameButtonManager(gameButton);
    }

    public void Pushing(PhotonView view)
    {
        m_GameButtonManager.ChangePushState(view);
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
