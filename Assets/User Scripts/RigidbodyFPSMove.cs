using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]

public class RigidbodyFPSMove : MonoBehaviour
{

    public float speed = 10.0f;
    public float gravity = 10.0f;
    public float maxVelocityChange = 10.0f;
    public bool canJump = true;
    public float jumpHeight = 2.0f;
    private bool grounded = false;
    private bool walled = false;

    public AudioClip Footsteps;

    void Awake()
    {
        GetComponent<Rigidbody>().freezeRotation = true;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<AudioSource>().clip = Footsteps;
    }

    void FixedUpdate()
    {
        if (grounded)
        {
            // Calculate how fast we should be moving
            Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            targetVelocity = transform.TransformDirection(targetVelocity);
            targetVelocity *= speed;

            // Apply a force that attempts to reach our target velocity
            Vector3 velocity = GetComponent<Rigidbody>().velocity;
            Vector3 velocityChange = (targetVelocity - velocity);
            velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
            velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
            velocityChange.y = 0;
            if (!walled)
            {
                GetComponent<Rigidbody>().AddForce(velocityChange, ForceMode.VelocityChange);
            }
            else 
            {
                GetComponent<Rigidbody>().AddForce(-velocityChange/10, ForceMode.VelocityChange);
            }

            // Jump
            if (canJump && Input.GetButton("Jump"))
            {
                GetComponent<Rigidbody>().velocity = new Vector3(velocity.x, CalculateJumpVerticalSpeed(), velocity.z);
            }


            if ((Input.GetKey("w") || Input.GetKey("d") || Input.GetKey("s") || Input.GetKey("a")) && !GetComponent<AudioSource>().isPlaying)
            {
                GetComponent<AudioSource>().Play();
            }

            if (!Input.GetKey("w") && !Input.GetKey("d") && !Input.GetKey("s") && !Input.GetKey("a"))
            {
                GetComponent<AudioSource>().Stop();
            }

        }
        else
            GetComponent<AudioSource>().Stop();

        // We apply gravity manually for more tuning control
        GetComponent<Rigidbody>().AddForce(new Vector3(0, -gravity * GetComponent<Rigidbody>().mass, 0));

        grounded = false;
    }

    void OnCollisionStay(Collision other)
    {
        grounded = true;
        if (other.collider.tag == "CannotBeShot" || other.collider.tag=="CanBeShot")
        {
            walled = true;
        }
        else walled = false;
    }

    float CalculateJumpVerticalSpeed()
    {
        // From the jump height and gravity we deduce the upwards speed 
        // for the character to reach at the apex.
        return Mathf.Sqrt(2 * jumpHeight * gravity);
    }
}