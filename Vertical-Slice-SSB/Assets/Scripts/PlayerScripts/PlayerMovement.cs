using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Movement Objects
    [SerializeField] public Rigidbody rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] public float jumpPower;

    [SerializeField] private float horizontalInput;

    [SerializeField] private string horizontalInputAxis;

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
            //Moves the player Left and Right based on the input
            Vector3 moveInput = new Vector3(horizontalInput, rb.velocity.y,  rb.velocity.z);
            rb.MovePosition(transform.position + moveInput * Time.deltaTime * moveSpeed);

            Vector3 lasPos = transform.position;
            float speed = (transform.position - lasPos).magnitude / Time.deltaTime;

        }
        else if(rb == null) // checks if the rigidbody is null
        {
            Debug.LogError("Rigidbody is Null!"); // logs a error message to the console
        }
    }
}
