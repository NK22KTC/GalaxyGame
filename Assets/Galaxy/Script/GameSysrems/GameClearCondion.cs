using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.tvOS;

public class GameClearCondion : IGameClearCondion
{
    protected List<PhotonView> CleardPlayers = new List<PhotonView>();
    protected bool isCleard = false;

    public List<PhotonView> m_CleardPlayers => CleardPlayers;
    public bool IsCleard => isCleard;

    public virtual bool CheckClear()
    {
        if (PhotonNetwork.PlayerList.Length == CleardPlayers.Count)
        {
            return true;
        }

        return false;
    }

    [PunRPC]
    public virtual void UpdateClearCondion(PhotonView view, bool isClear)
    {
        if (!isClear)
        {
            CleardPlayers.Remove(view);
            return;
        }

        CleardPlayers.Add(view);
        isCleard = CheckClear();

        if (isCleard)
        {
            Debug.Log("Clear!!");
        }
    }
}
