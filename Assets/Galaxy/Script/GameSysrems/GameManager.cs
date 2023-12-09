using Photon.Pun;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PhotonView m_View => GetComponent<PhotonView>();

    [PunRPC]
    private GameClearCondion GameClearCondion = new GameClearButtonPush();
    public IGameClearCondion m_IGameClearCondion => GameClearCondion;
    public bool IsGameClear => GameClearCondion.IsCleard;
}
