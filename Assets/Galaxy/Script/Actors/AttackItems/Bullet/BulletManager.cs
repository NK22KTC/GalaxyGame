using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviourPunCallbacks
{
    /// <summary> 消滅するまでの時間 </summary>
    [SerializeField] float ExtinguishedTime = 5f;

    /// <summary> 飛ばす力 </summary>
    [SerializeField] float forcePower = 10f;

    public PlayerManager ownerPlayer;
    // Start is called before the first frame update
    void Start()
    {
        if(!GetComponent<PhotonView>().IsMine) { Destroy(this); }
        GetComponent<Rigidbody>().AddForce(transform.forward * forcePower * 100, ForceMode.Acceleration);
    }

    // Update is called once per frame
    void Update()
    {
        ExtinguishedTime -= Time.deltaTime;
        if (ExtinguishedTime <= 0)
        {
            PhotonNetwork.Destroy(gameObject);
        }
    }

    //障害物に当たったら消去する
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.TryGetComponent(out IEnemy enemy))
        {
            // マジックナンバーを後で消す
            enemy.m_HitPointHandler.Damage(10, ownerPlayer);
        }

        PhotonNetwork.Destroy(gameObject);
    }
}
