
using Photon.Pun;

public interface IGameClearCondion
{
    bool IsCleard { get; }
    bool CheckClear();
    void UpdateClearCondion(PhotonView view, bool isClear);
}
