using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [Header("このスクリプトはプレイヤーの配下に置いたカメラ専用です")]
    [SerializeField]
    //PlayerSettings m_PlayerSettings;

    PlayerStatePresenter m_StatePresenter;
    PlayerInputPresenter m_InputPresenter;

    void Start()
    {
        m_StatePresenter = transform.parent.GetComponent<PlayerManager>().m_StatePresenter;
        m_InputPresenter = transform.parent.GetComponent<PlayerManager>().m_InputPresenter;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_StatePresenter.canLook)
        {
            RotateCamera().LockCameraRotate();
        }
    }

    CameraControl RotateCamera()
    {
        var rotate_direction = m_InputPresenter.Rotate.y;
        // オブジェクトからみて垂直方向を軸として回転させるQuaternionを作成
        Quaternion rot = Quaternion.AngleAxis(rotate_direction * GeneralSettings.Instance.m_PlayerSettings.RotateSpeed, -transform.right);
        
        Quaternion newQ = rot * transform.rotation;
        // 合成して、自身に設定
        transform.rotation = rot * transform.rotation;

        return this;
    }

    void LockCameraRotate()
    {
        if (transform.localRotation.x < GeneralSettings.Instance.m_PlayerSettings.UpperQ.x)
        {
            transform.localRotation = new Quaternion(GeneralSettings.Instance.m_PlayerSettings.UpperQ.x, 0, 0, transform.localRotation.w);
        }
        if (transform.localRotation.x > GeneralSettings.Instance.m_PlayerSettings.LowerQ.x)
        {
            transform.localRotation = new Quaternion(GeneralSettings.Instance.m_PlayerSettings.LowerQ.x, 0, 0, transform.localRotation.w);
        }
    }
}
