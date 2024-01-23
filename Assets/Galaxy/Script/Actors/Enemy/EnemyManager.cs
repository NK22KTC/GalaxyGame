using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviourPunCallbacks, IEnemy, INetworkObject
{
    private EnemyStatusManager EnemyStatusManager;
    private EnemyController EnemyController;
    private IGroundGimmick GroundGimmick;
    private float walkSpeed;

    public EnemyStatusManager m_EnemyStatusManager => EnemyStatusManager;
    public EnemyController m_EnemyController => EnemyController;
    public IGroundGimmick m_GroundGimmick => GroundGimmick;
    public float WalkSpeed => walkSpeed;
    public IActorStatus m_ActorStatus => m_EnemyStatusManager;

    public IHitPointHandler m_HitPointHandler => m_EnemyStatusManager;

    public bool DoingTransfer => throw new System.NotImplementedException();

    public void GetGroundInfo(GroundManager GroundGimmick)
    {
        this.GroundGimmick = GroundGimmick;
    }

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
        
    }

    void Start()
    {
        EnemyStatusManager = new EnemyStatusManager(this);
        EnemyController = new EnemyController(this);
        walkSpeed = GeneralSettings.Instance.m_EnemySettings.WalkSpeed;
    }
}
