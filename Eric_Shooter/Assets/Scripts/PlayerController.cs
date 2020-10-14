using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private CharacterController player;

    public Vector3 direction = Vector3.zero;

    public float walkingSpeed;
    public float jumpForce;

    public float gravityMultiplier;
    public float gravity;

    public bool isGrounded = false;

    public CollisionFlags collisionesdelPlayer = CollisionFlags.None;

    public Camera myCamera;

    public Quaternion playerInitialRotationt;
    public Quaternion camerInitialRotation;
    public float cameraAngleX;

    public float mouseXSensibility = 1.0f;
    public float mouseYSensibility = 1.0f;

    public bool invertY = false;

    public float topAngleY = 45.0f;
    public float botAngleY = -45.0f;

    private Rigidbody rigidBody;

    public bool isDead = false;

    public int health = 0;
    public int shield = 0;
    public int ammo = 0;
    public int savedAmmo = 0;
    public bool hasKey = false;

    Shooter shooter;


    // Start is called before the first frame update
    void Start()
    {
        rigidBody = this.GetComponent<Rigidbody>();
        shooter = this.GetComponent<Shooter>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate ()
    {
        float dir_x = Input.GetAxis("Horizontal");
        float dir_z = Input.GetAxis("Vertical");

        float mouse_x = Input.GetAxis("Mouse X");
        float mouse_Y = Input.GetAxis("Mouse Y");

        int invert = invertY ? -1 : 1;

        cameraAngleX += mouse_Y * mouseYSensibility * invert;
        cameraAngleX = Mathf.Clamp(cameraAngleX, botAngleY, topAngleY);

        Quaternion angle_mouseX = Quaternion.Euler(0.0f, mouse_x * mouseXSensibility, 0.0f);
        Quaternion angle_mouseY = Quaternion.Euler(cameraAngleX, 0.0f, 0.0f);

        transform.localRotation *= angle_mouseX;
        myCamera.transform.localRotation = angle_mouseY;

        float runMultiplier = (Input.GetAxis("Run") > 0) ? 2.0f : 1.0f;

        direction.x = dir_x * walkingSpeed * runMultiplier;
        direction.z = dir_z * walkingSpeed * runMultiplier;

        direction.y = -gravity * gravityMultiplier;

        direction = Quaternion.FromToRotation(Vector3.forward, transform.forward) * direction;

        player.Move(direction * Time.deltaTime);

        if ((Input.GetAxis("Jump") > 0) && (isGrounded))
        {
            direction.y = jumpForce;
            if (jumpForce > 0.0f)
            {
                rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }

        rigidBody.AddForce(-transform.up * gravity * gravityMultiplier);

        isGrounded = player.isGrounded;

        if (Input.GetAxis("Cancel") > 0)
        {
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

}
