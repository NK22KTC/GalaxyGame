using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    public GameObject myCamera;

    public void IsLocalPlayer(PlayerSetup mySetUp)
    {
        var playerSetUps = FindObjectsOfType<PlayerSetup>();
        foreach (var setUp in playerSetUps)
        {
            if (setUp == mySetUp)
            {
                ActiveComponent();
                myCamera.SetActive(true);
            }
            else
            {
                Destroy(setUp.myCamera);
            }
        }

        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.NickName = "MasterClientPlayer";
        }
        else
        {
            PhotonNetwork.NickName = "ClientPlayer";
        }
    }

    void ActiveComponent()
    {
        if (!TryGetComponent(out PlayerManager manager))
        {
            manager = gameObject.AddComponent<PlayerManager>();
        }
        if (!TryGetComponent(out PlayerController controller))
        {
            controller = gameObject.AddComponent<PlayerController>();
        }

        manager.m_Camera = myCamera;
    }

    public void DestroyPlayerConponent(PlayerSetup setUp)
    {
        Destroy(setUp.GetComponent<PlayerManager>());
        Destroy(setUp.GetComponent<PlayerController>());
    }
}
