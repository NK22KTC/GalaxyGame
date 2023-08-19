using UnityEngine;

public class test : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float jumpForce = 5.0f;
    public float mouseSensitivity = 2.0f;

    private float verticalRotation = 0;
    private float verticalVelocity = 0;

    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // �L�[�{�[�h�ɂ��ړ�����
        float forwardSpeed = Input.GetAxis("Vertical") * moveSpeed;
        float sidewaysSpeed = Input.GetAxis("Horizontal") * moveSpeed;

        // �}�E�X�ɂ�鎋�_�ύX����
        float horizontalRotation = Input.GetAxis("Mouse X") * mouseSensitivity;
        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -60.0f, 60.0f);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
        transform.Rotate(0, horizontalRotation, 0);

        // �W�����v����
        if (characterController.isGrounded && Input.GetButtonDown("Jump"))
        {
            verticalVelocity = jumpForce;
        }

        // �d�͏���
        verticalVelocity += Physics.gravity.y * Time.deltaTime;

        // �ړ�����
        Vector3 speed = new Vector3(sidewaysSpeed, verticalVelocity, forwardSpeed);
        speed = transform.rotation * speed;
        characterController.Move(speed * Time.deltaTime);
    }
}