using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClearCondion : IGameClearCondion
{
    protected List<int> CleardPlayers = new List<int>();
    protected bool isCleard = false;

    public List<int> m_CleardPlayers => CleardPlayers;
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
    public virtual void UpdateClearCondion(int viewId, bool isClear)
    {
        Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
        if (!isClear)
        {
            CleardPlayers.Remove(viewId);
            return;
        }

        CleardPlayers.Add(viewId);
        isCleard = CheckClear();

        if (isCleard)
        {
            Debug.Log("Clear!!");
        }
    }
}
