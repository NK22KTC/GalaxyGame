using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class EnemyController
{
    private EnemyManager EnemyManager;

    PhotonView target = null;

    public EnemyController(EnemyManager EnemyManager)
    {
        this.EnemyManager = EnemyManager;
    }

    void Start()
    {
        
    }

    void Update()
    {

    }

    private void UpdateTarget(PhotonView[] views)
    {
        var view = GetTarget(views);
        EnemyManager.PassPhotonView().RPC(nameof(SetTarget), RpcTarget.AllBuffered, view);
    }

    [PunRPC]
    private void SetTarget(PhotonView playerView) => target = playerView;

    private PhotonView GetTarget(PhotonView[] targets)
    {
        return ArrayExpansion<PhotonView>.Random(targets);
    }
}
