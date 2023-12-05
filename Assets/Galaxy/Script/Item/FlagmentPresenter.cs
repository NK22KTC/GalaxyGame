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

    // IPunOwnershipCallbacks.OnOwnershipTransfered������
    void IPunOwnershipCallbacks.OnOwnershipTransfered(PhotonView targetView, Player previousOwner)
    {
        Debug.LogFormat("{0}�̏��L�҂�{1}�ɂȂ�܂����B", targetView, previousOwner);
        // �l�b�g���[�N�I�u�W�F�N�g���폜
        //PhotonNetwork.Destroy(targetView.gameObject);
        //Debug.Log("aaaaa");
        //Player player = PhotonNetwork.LocalPlayer;
        //PhotonNetwork.Destroy(gameObject);  //�������Ŕj�����Ăяo������_������
    }

    // �ȉ��̃��\�b�h���������Ȃ��ƃG���[���o��
    void IPunOwnershipCallbacks.OnOwnershipTransferFailed(PhotonView targetView, Player previousOwner)
    {
        
    }

    void IPunOwnershipCallbacks.OnOwnershipRequest(PhotonView targetView, Player requestingPlayer)
    {

    }
}
