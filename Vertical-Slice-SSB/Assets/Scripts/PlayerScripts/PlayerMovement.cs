using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Movement Objects
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpPower;

    //GroundCheck Objects
    [SerializeField] private GameObject groundCheckObj;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private bool groundCheckBool;

    [SerializeField] private float horizontalInput;

    [SerializeField] private string horizontalInputAxis;
    [SerializeField] private string jumpAxis;
    //private float verticalInput;

    void Start()
    {
        FindPlayerTag();
    }
    private void FindPlayerTag()
    {
        rb = transform.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis(horizontalInputAxis);
        Move();
    }

    private void Move()
    {
        if (rb != null) // checks if the rigidbody isn't null
        {
            //Updates the GroundCheck bool every time Move() gets called
            GroundCheck();

            //Moves the player Left and Right based on the input
            Vector3 moveInput = new Vector3(horizontalInput, rb.velocity.y,  rb.velocity.z);
            rb.MovePosition(transform.position + moveInput * Time.deltaTime * moveSpeed);

            //lets the player jump when W or Space is pressed
            if (groundCheckBool == true)
            {
                rb.velocity = new Vector3(rb.velocity.x,Input.GetAxis(jumpAxis) * jumpPower, rb.velocity.z);
            }
        }
        else if(rb == null) // checks if the rigidbody is null
        {
            Debug.LogError("Rigidbody is Null!"); // logs a error message to the console
        }
    }
    private bool GroundCheck()
    {
        // checks if the groundcheck is in a small radius of the Ground layer
        groundCheckBool = Physics.CheckSphere(groundCheckObj.transform.position, 0.5f, groundLayer);
        return groundCheckBool;
    }
}
