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

    public PhotonView PassPhotonView(out PhotonView view)
    {
        return view = GetComponent<PhotonView>();
    }

    // IPunOwnershipCallbacks.OnOwnershipTransferedを実装
    void IPunOwnershipCallbacks.OnOwnershipTransfered(PhotonView targetView, Player previousOwner)
    {
        Debug.LogFormat("{0}の所有者は{1}になりました。", targetView, previousOwner);
        // ネットワークオブジェクトを削除
        //PhotonNetwork.Destroy(targetView.gameObject);
        //Debug.Log("aaaaa");
        //Player player = PhotonNetwork.LocalPlayer;
        //PhotonNetwork.Destroy(gameObject);  //こっちで破棄を呼び出したらダメかも
    }

    // 以下のメソッドも実装しないとエラーが出る
    void IPunOwnershipCallbacks.OnOwnershipTransferFailed(PhotonView targetView, Player previousOwner)
    {
        
    }

    void IPunOwnershipCallbacks.OnOwnershipRequest(PhotonView targetView, Player requestingPlayer)
    {

    }
}
