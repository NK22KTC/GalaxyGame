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

    /// <summary> ���������̉�]�𐧌䂷�� </summary>
    public static Quaternion CalcHorizontalRotate(float inputX, Transform transform)
    {
        var rotate_direction = inputX;

        // �I�u�W�F�N�g����݂Đ������������Ƃ��ĉ�]������Quaternion���쐬
        Quaternion rot = Quaternion.AngleAxis(rotate_direction * GeneralSettings.Instance.m_PlayerSettings.RotateSpeed, transform.up);
        // ���݂̎��M�̉�]�̏����擾����B
        Quaternion q = transform.rotation;
        // �������āA���g�ɐݒ�
        Quaternion outputQ = rot * q;
        return outputQ;
    }

    /// <summary> ���������̉�]�𐧌䂷�� </summary>
    public static Quaternion CalcVerticalRotate(CameraControl cameraControl, float inputY, Transform transform)
    {
        Quaternion outputQ = transform.rotation;
        var rotate_direction = inputY;

        // �I�u�W�F�N�g����݂Đ������������Ƃ��ĉ�]������Quaternion���쐬
        Quaternion rot = Quaternion.AngleAxis(rotate_direction * GeneralSettings.Instance.m_PlayerSettings.RotateSpeed, -transform.right);
        // ���݂̎��M�̉�]�̏����擾����B
        Quaternion q = transform.rotation;
        // �������āA���g�ɐݒ�
        outputQ = rot * q;

        outputQ = LockVerticalRotate(transform, inputQ: outputQ);

        return outputQ;
    }

    /// <summary> CalcVerticalRotate �̉�]�𐧌�����</summary>
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
