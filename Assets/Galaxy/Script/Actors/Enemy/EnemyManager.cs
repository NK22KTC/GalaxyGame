using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviourPunCallbacks, IEnemy, INetworkObject
{
    EnemyStatusManager EnemyStatusManager;

    public float WalkSpeed => GeneralSettings.Instance.m_EnemySettings.WalkSpeed;

    public EnemyStatusManager m_EnemyStatusManager => EnemyStatusManager;

    public IActorStatus m_ActorStatus => m_EnemyStatusManager;

    public IHitPointHandler m_HitPointHandler => m_EnemyStatusManager;

    public bool DoingTransfer => throw new System.NotImplementedException();

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
        throw new System.NotImplementedException();
    }

    void Start()
    {
        EnemyStatusManager = new EnemyStatusManager(this);
    }
}
