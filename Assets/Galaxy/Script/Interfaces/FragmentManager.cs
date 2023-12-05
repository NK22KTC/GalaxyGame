using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItemDestroyable
{
    PhotonView PassPhotonView(out PhotonView view);
}

public interface IFragmentable: IItemDestroyable
{
    public FragmentType FragmentType { get; }
}