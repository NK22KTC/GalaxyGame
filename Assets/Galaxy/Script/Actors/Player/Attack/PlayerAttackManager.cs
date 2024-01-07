using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackManager
{
    private readonly GameObject PlayerObject;
    private readonly GameObject CameraObject;
    private GameObject m_Bullet => GeneralSettings.Instance.m_Prehabs.Bullet;

    public PlayerAttackManager(GameObject player, GameObject camera)
    {
        PlayerObject = player;
        CameraObject = camera;
    }

    public void Attack()
    {
        // プレイヤーとカメラを分離したらQuaternion はCameraObject.transform.rotation にする
        var bullet = PhotonNetwork.Instantiate(m_Bullet.name, PlayerObject.transform.position + PlayerObject.transform.right, PlayerObject.transform.rotation * CameraObject.transform.localRotation);
        bullet.GetComponent<BulletManager>().ownerPlayer = PlayerObject.GetComponent<PlayerManager>();
    }
}
