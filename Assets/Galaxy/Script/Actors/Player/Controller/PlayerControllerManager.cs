using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerManager
{
    private readonly Transform playertransform;
    private readonly Transform cameraTransform;
    
    public Transform PlayerTransform => playertransform;
    public Transform CameraTransform => cameraTransform;

    //���������ŃC���X�^���X�����Ȃ��悤��
    private PlayerControllerManager()
    {

    }

    public PlayerControllerManager(Transform playertransform, Transform cameraTransform)
    {
        this.playertransform = playertransform;
        this.cameraTransform = cameraTransform;
    }
}
