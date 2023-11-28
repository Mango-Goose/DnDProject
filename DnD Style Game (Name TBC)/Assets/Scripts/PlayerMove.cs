using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] public float moveSpeed;

    float horizontalMovement;
    float verticalMovement;

    Vector3 moveDir;

    [SerializeField] Transform orientation;

    [SerializeField] Rigidbody rb;

    bool isOnGround = true;
    [SerializeField] LayerMask ground;

    private void Awake()
    {
        
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.freezeRoatation = true;
    }

    private void Update()
    {
        MyInput();

        //adding in the options for a jump and sprint to the player controller - very basic + can work on it being nicer later
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            PlayerSprint();
        }

        if(isOnGround && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        print(isOnGround);
    }

    void MyInput()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");

        moveDir = orientation.forward * verticalMovement + orientation.right * horizontalMovement;
    }


    private void FixedUpdate()
    {
        MovePlayer();
    }

    public void MovePlayer()
    {
        rb.AddForce(moveDir.normalized *moveSpeed, ForceMode.Acceleration);
    }

    public void PlayerSprint()
    {
        print("Sprinting");
        rb.AddForce(moveDir.normalized * (moveSpeed*50), ForceMode.Acceleration);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 6)
        {
            isOnGround = true;
        }
        else
        {
            isOnGround = false;
        }
    }

    public void Jump()
    {
        isOnGround = false;
        print("jump");
        rb.AddForce((Vector3.up*8), ForceMode.Impulse);
    }
}
