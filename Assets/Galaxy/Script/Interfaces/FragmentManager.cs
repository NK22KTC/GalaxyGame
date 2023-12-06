using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITransfer
{
    bool OwnershipTransfered { get; }
}

public interface IItemDestroyable
{
    PhotonView PassPhotonView(out PhotonView view);
}

public interface IFragment: IItemDestroyable, ITransfer
{
    public FragmentType FragmentType { get; }
}