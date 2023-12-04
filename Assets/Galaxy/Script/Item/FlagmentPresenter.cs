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
        // �l�b�g���[�N�I�u�W�F�N�g���폜
        PhotonNetwork.Destroy(targetView.gameObject);
    }

    // �ȉ��̃��\�b�h���������Ȃ��ƃG���[���o��
    public void OnOwnershipTransferFailed(PhotonView targetView, Player previousOwner)
    {

    }

    public void OnOwnershipRequest(PhotonView targetView, Player requestingPlayer)
    {

    }
}
