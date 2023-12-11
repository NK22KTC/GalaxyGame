
using Photon.Pun;
using System.Collections.Generic;

public interface IGameClearCondion
{
    public List<int> m_CleardPlayers { get; }

    bool IsCleard { get; }
    bool CheckClear();
    void UpdateClearCondion(int viewId, bool isClear);
}
