using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FlagmentPresenter : MonoBehaviourPunCallbacks, IFragmentable, IPunOwnershipCallbacks
{
    [SerializeField]
    FragmentType fragmentType;
    public FragmentType FragmentType => fragmentType;

    void Start()
    {
        
    }

    public void PassObject()
    {
        GetComponent<PhotonView>().TransferOwnership(PhotonNetwork.LocalPlayer);
        Debug.Log(GetComponent<PhotonView>().Owner);
    }

    public void OnOwnershipTransfered(PhotonView targetView, Player previousOwner)
    {
        // ネットワークオブジェクトを削除
        PhotonNetwork.Destroy(targetView.gameObject);
    }

    // 以下のメソッドも実装しないとエラーが出る
    public void OnOwnershipTransferFailed(PhotonView targetView, Player previousOwner)
    {

    }

    public void OnOwnershipRequest(PhotonView targetView, Player requestingPlayer)
    {

    }
}
