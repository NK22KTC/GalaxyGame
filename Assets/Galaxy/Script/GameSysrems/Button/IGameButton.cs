using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameButton : INetworkObject
{
    bool IsPushed { get; }
    void Pushing(PhotonView view);
}
