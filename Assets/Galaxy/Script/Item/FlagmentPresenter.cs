using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FlagmentPresenter : MonoBehaviourPunCallbacks, IFragment, IPunOwnershipCallbacks
{
    [SerializeField]
    FragmentType fragmentType;
    public FragmentType FragmentType => fragmentType;


    private bool ownershipTransfered = false;
    /// <summary> オブジェクトの所有権が移ったらtrue </summary>
    public bool OwnershipTransfered => ownershipTransfered;

    void Start()
    {
        
    }

    public PhotonView PassPhotonView(out PhotonView view)
    {
        return view = GetComponent<PhotonView>();
    }

    // このスクリプトがついているネットワークオブジェクトの所有者が変更された時に呼び出される
    void IPunOwnershipCallbacks.OnOwnershipTransfered(PhotonView targetView, Player previousOwner)
    {
        Debug.Log($"{targetView}の所有者は{previousOwner}になりました。");
        ownershipTransfered = true;
    }

    // 以下のメソッドも実装しないとエラーが出る
    void IPunOwnershipCallbacks.OnOwnershipTransferFailed(PhotonView targetView, Player previousOwner)
    {
        
    }

    void IPunOwnershipCallbacks.OnOwnershipRequest(PhotonView targetView, Player requestingPlayer)
    {

    }
}
