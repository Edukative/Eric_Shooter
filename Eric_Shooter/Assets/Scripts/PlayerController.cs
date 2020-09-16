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

    private Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = this.GetComponent<Rigidbody>()
    }

    // Update is called once per frame
    void Update()
    {
        float dir_x = Input.GetAxis("Horizontal");
        float dir_z = Input.GetAxis("Vertical");

        float mouse_x = Input.GetAxis("Mouse X");
        float mouse_Y = Input.GetAxis("Mouse Y");
    }
}
