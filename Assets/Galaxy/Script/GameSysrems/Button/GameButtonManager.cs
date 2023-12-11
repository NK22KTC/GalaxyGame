using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameButtonManager
{
    private Transform button;
    bool isPushed = false;
    public bool IsPushed => isPushed;

    internal GameButtonManager(Transform buttonTransform)
    {
        button = buttonTransform;
    }

    public void ChangePushState()
    {
        if (isPushed) { return; }
        isPushed = true;
        button.position = new Vector3(button.position.x, button.position.y - 0.07f, button.position.z);
    }
}