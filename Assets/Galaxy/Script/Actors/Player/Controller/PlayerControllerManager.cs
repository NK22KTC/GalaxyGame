using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerManager
{
    private readonly Transform playertransform;
    private readonly Transform cameraTransform;
    
    public Transform PlayerTransform => playertransform;
    public Transform CameraTransform => cameraTransform;

    //引数無しでインスタンスを作らないように
    private PlayerControllerManager()
    {

    }

    public PlayerControllerManager(Transform playertransform, Transform cameraTransform)
    {
        this.playertransform = playertransform;
        this.cameraTransform = cameraTransform;
    }
}
