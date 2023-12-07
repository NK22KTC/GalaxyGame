using UnityEngine;

public static class LocomotionCalculator
{
    public static Vector3 CalcPlayerMovement(Rigidbody rb, PlayerManager playerManaher, Vector3 input)
    {
        Vector3 targetVelocity = playerManaher.transform.TransformDirection(input);

        targetVelocity *= PlayerInputPresenter.isSprint ? GeneralSettings.Instance.m_PlayerSettings.SprintSpeed : GeneralSettings.Instance.m_PlayerSettings.WalkSpeed;

        if (input.magnitude > 0.5f)
        {
            Vector3 velocityChange = targetVelocity - rb.velocity;

            velocityChange.x = Mathf.Clamp(velocityChange.x, -GeneralSettings.Instance.m_PlayerSettings.MaxAcceleration, GeneralSettings.Instance.m_PlayerSettings.MaxAcceleration);
            velocityChange.z = Mathf.Clamp(velocityChange.z, -GeneralSettings.Instance.m_PlayerSettings.MaxAcceleration, GeneralSettings.Instance.m_PlayerSettings.MaxAcceleration);

            velocityChange.y = 0;

            return velocityChange;
        }
        else
        {
            return new Vector3();
        }
    }

    /// <summary> 水平方向の回転を制御する </summary>
    public static Quaternion CalcHorizontalRotate(float inputX, Transform transform)
    {
        var rotate_direction = inputX;

        // オブジェクトからみて垂直方向を軸として回転させるQuaternionを作成
        Quaternion rot = Quaternion.AngleAxis(rotate_direction * GeneralSettings.Instance.m_PlayerSettings.RotateSpeed, transform.up);
        // 現在の自信の回転の情報を取得する。
        Quaternion q = transform.rotation;
        // 合成して、自身に設定
        Quaternion outputQ = rot * q;
        return outputQ;
    }

    /// <summary> 垂直方向の回転を制御する </summary>
    public static Quaternion CalcVerticalRotate(CameraControl cameraControl, float inputY, Transform transform)
    {
        Quaternion outputQ = transform.rotation;
        var rotate_direction = inputY;

        // オブジェクトからみて垂直方向を軸として回転させるQuaternionを作成
        Quaternion rot = Quaternion.AngleAxis(rotate_direction * GeneralSettings.Instance.m_PlayerSettings.RotateSpeed, -transform.right);
        // 現在の自信の回転の情報を取得する。
        Quaternion q = transform.rotation;
        // 合成して、自身に設定
        outputQ = rot * q;

        outputQ = LockVerticalRotate(transform, inputQ: outputQ);

        return outputQ;
    }

    /// <summary> CalcVerticalRotate の回転を制限する</summary>
    private static Quaternion LockVerticalRotate(Transform transform, Quaternion inputQ)
    {
        var outputQ = inputQ;
        if (outputQ.x < GeneralSettings.Instance.m_PlayerSettings.UpperQ.x)
        {
            outputQ = new Quaternion(GeneralSettings.Instance.m_PlayerSettings.UpperQ.x, 0, 0, outputQ.w);
        }
        if (outputQ.x > GeneralSettings.Instance.m_PlayerSettings.LowerQ.x)
        {
            outputQ = new Quaternion(GeneralSettings.Instance.m_PlayerSettings.LowerQ.x, 0, 0, outputQ.w);
        }
        return outputQ;
    }

    public static void CalcJump(Rigidbody rb)
    {
        //rb.velocity = new Vector3(0, GeneralSettings.Instance.m_PlayerSettings.JumpHeight, 0);
        rb.AddForce(new Vector3(0, GeneralSettings.Instance.m_PlayerSettings.JumpHeight, 0));
    }
}
