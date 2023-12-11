using Photon.Pun;
using UnityEngine;

public class GameManager : MonoBehaviourPunCallbacks
{
    private PhotonView view;
    public PhotonView m_View => view;

    private GameClearCondion GameClearCondion = new GameClearCondion();
    public IGameClearCondion m_IGameClearCondion => GameClearCondion;
    public bool IsGameClear => GameClearCondion.IsCleard;
    [PunRPC] public void UpdateClearCondion(int viewId) => m_IGameClearCondion.UpdateClearCondion(viewId, true);

    private void Awake()
    {
        view = GetComponent<PhotonView>();
    }
}
