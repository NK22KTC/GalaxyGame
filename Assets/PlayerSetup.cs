using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    [SerializeField]
    public Movement movement;
    [SerializeField]
    PlayerController PlayerController;

    public GameObject myCamera;

    public void IsLocalPlayer()
    {
        if (movement != null) movement.enabled = true;
        else PlayerController.enabled = true;
        myCamera.SetActive(true);
    }
}
