using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FlagmentPresenter : MonoBehaviourPunCallbacks, IFragment
{
    [SerializeField]
    FragmentType fragmentType;
    private bool doingTransfer = false;
    public FragmentType FragmentType => fragmentType;
    public bool DoingTransfer => doingTransfer;

    public PhotonView PassPhotonView(out PhotonView view)
    {
        return view = GetComponent<PhotonView>();
    }

    public void UpdateTransferSituation()
    {
        doingTransfer = true;
    }
}
