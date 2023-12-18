using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviourPunCallbacks
{
    /// <summary> ���ł���܂ł̎��� </summary>
    [SerializeField] float ExtinguishedTime = 5f;

    /// <summary> ��΂��� </summary>
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

    //��Q���ɓ����������������
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.TryGetComponent(out IEnemy enemy))
        {
            // �}�W�b�N�i���o�[����ŏ���
            enemy.m_HitPointHandler.Damage(10, ownerPlayer);
        }

        PhotonNetwork.Destroy(gameObject);
    }
}
