using Photon.Pun;
using UnityEngine;


public class FlagmentPresenter : MonoBehaviourPunCallbacks, IFragment
{
    [SerializeField]
    FragmentType fragmentType;
    private bool doingTransfer = false;
    public FragmentType FragmentType => fragmentType;
    public bool DoingTransfer => doingTransfer;

    public PhotonView PassPhotonView()
    {
        return GetComponent<PhotonView>();
    }
    public PhotonView PassPhotonView(out PhotonView view)
    {
        return view = GetComponent<PhotonView>();
    }

    public void UpdateTransferSituation()
    {
        doingTransfer = true;
    }
}
