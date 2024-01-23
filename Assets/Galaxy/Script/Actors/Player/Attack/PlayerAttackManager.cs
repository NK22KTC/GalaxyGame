using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackManager
{
    private readonly GameObject PlayerObject;
    private readonly GameObject CameraObject;

    private GameObject bullet;

    public PlayerAttackManager(GameObject player, GameObject camera)
    {
        PlayerObject = player;
        CameraObject = camera;

        bullet = GeneralSettings.Instance.m_Prehabs.Bullet;
    }

    public void Attack()
    {
        // プレイヤーとカメラを分離したらQuaternion はCameraObject.transform.rotation にする
        var instBullet = PhotonNetwork.Instantiate(bullet.name, PlayerObject.transform.position + PlayerObject.transform.right, PlayerObject.transform.rotation * CameraObject.transform.localRotation);
        instBullet.GetComponent<BulletManager>().ownerPlayer = PlayerObject.GetComponent<PlayerManager>();
    }
}
