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
        // キーボードによる移動処理
        float forwardSpeed = Input.GetAxis("Vertical") * moveSpeed;
        float sidewaysSpeed = Input.GetAxis("Horizontal") * moveSpeed;

        // マウスによる視点変更処理
        float horizontalRotation = Input.GetAxis("Mouse X") * mouseSensitivity;
        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -60.0f, 60.0f);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
        transform.Rotate(0, horizontalRotation, 0);

        // ジャンプ処理
        if (characterController.isGrounded && Input.GetButtonDown("Jump"))
        {
            verticalVelocity = jumpForce;
        }

        // 重力処理
        verticalVelocity += Physics.gravity.y * Time.deltaTime;

        // 移動処理
        Vector3 speed = new Vector3(sidewaysSpeed, verticalVelocity, forwardSpeed);
        speed = transform.rotation * speed;
        characterController.Move(speed * Time.deltaTime);
    }
}