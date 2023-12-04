using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float walkSpeed = 8f;
    public float sprintSpeed = 14f;
    public float maxAcceleration = 10f;

    [Space]
    public float airControl = 0.5f;
    
    [Space]
    public float jumpHeight = 30f;

    private Vector2 input;
    private Rigidbody rb;

    private bool sprinting;
    private bool jumping;

    private bool grounded = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        input.Normalize();

        sprinting = Input.GetButton("Sprint");
        jumping = Input.GetButton("Jump");
    }

    private void OnTriggerStay(Collider other)
    {
        grounded = true;
    }

    private void FixedUpdate()
    {
        if (grounded)
        {
            if(jumping) 
            {
                 rb.velocity = new Vector3(rb.velocity.x, jumpHeight, rb.velocity.z);           
            }
            else if (input.magnitude > 0.5f)
            {
                rb.AddForce(CalculateMovement(), ForceMode.VelocityChange);
            }
            else
            {
                var velocity = rb.velocity;
                velocity = new Vector3(velocity.x * 0.2f * Time.fixedDeltaTime, velocity.y, velocity.z * 0.2f * Time.fixedDeltaTime);
                rb.velocity = velocity;
            }
        } 

        else
        {
            if (input.magnitude > 0.5f)
            {
                rb.AddForce(CalculateMovement(), ForceMode.VelocityChange);
            }
            else
            {
                var velocity1 = rb.velocity;
                velocity1 = new Vector3(velocity1.x * 0.2f * Time.fixedDeltaTime, velocity1.y, velocity1.z * 0.2f * Time.fixedDeltaTime);
                rb.velocity = velocity1;
            }
        }

        grounded = false;
        
    }

    /// <summary>
    /// <see cref="input"/>の大きさが0.5f以上の時に使う
    /// </summary>
    Vector3 CalculateMovement()
    {
        Vector3 targetVelocity = transform.TransformDirection(input.x, 0, input.y);
        float moveSpeed = (sprinting ? sprintSpeed : walkSpeed) * (grounded ? 1 : airControl);
        targetVelocity *= moveSpeed;

        Vector3 force = targetVelocity - rb.velocity;


        force = new Vector3(Mathf.Clamp(force.x, -maxAcceleration, maxAcceleration),
                            0,
                            Mathf.Clamp(force.z, -maxAcceleration, maxAcceleration));

        return force;

        //ここはif文が必ずtrueになるからifの中身だけ使えばいい
        //if(input.magnitude > 0.5f)
        //{
        //    Vector3 velocityChange = targetVelocity - velocity;

        //    velocityChange.x = Mathf.Clamp(velocityChange.x, -maxAcceleration, maxAcceleration);
        //    velocityChange.z = Mathf.Clamp(velocityChange.z, -maxAcceleration, maxAcceleration);

        //    velocityChange.y = 0;

        //    return velocityChange;
        //}
        //else
        //{
        //    return new Vector3();
        //}
    }

}
