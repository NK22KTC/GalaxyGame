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
    /// <summary> �I�u�W�F�N�g�̏��L�����ڂ�����true </summary>
    public bool OwnershipTransfered => ownershipTransfered;

    void Start()
    {
        
    }

    public PhotonView PassPhotonView(out PhotonView view)
    {
        return view = GetComponent<PhotonView>();
    }

    // ���̃X�N���v�g�����Ă���l�b�g���[�N�I�u�W�F�N�g�̏��L�҂��ύX���ꂽ���ɌĂяo�����
    void IPunOwnershipCallbacks.OnOwnershipTransfered(PhotonView targetView, Player previousOwner)
    {
        Debug.Log($"{targetView}�̏��L�҂�{previousOwner}�ɂȂ�܂����B");
        ownershipTransfered = true;
    }

    // �ȉ��̃��\�b�h���������Ȃ��ƃG���[���o��
    void IPunOwnershipCallbacks.OnOwnershipTransferFailed(PhotonView targetView, Player previousOwner)
    {
        
    }

    void IPunOwnershipCallbacks.OnOwnershipRequest(PhotonView targetView, Player requestingPlayer)
    {

    }
}
