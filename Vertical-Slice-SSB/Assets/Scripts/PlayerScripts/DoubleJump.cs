using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Drawing;
using UnityEngine;
using UnityEngine.XR;

public class DoubleJump : MonoBehaviour
{
    [SerializeField] private float jumpAmount = 1f;
    [SerializeField] private float jumpPower = 1f;
    [SerializeField] private PlayerMovement playerMovement;

    //GroundCheck Objects
    [SerializeField] private GameObject groundCheckObj;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] public bool groundCheckBool;

    [SerializeField] private float jumpInput;
    [SerializeField] public string jumpAxis;

    //Multiple Jumps
    [SerializeField] private bool canJump;
    [SerializeField] private bool CanDoubleJump;
    [SerializeField] private bool CanJumpMore = false;

    [SerializeField] string characterName;

    [SerializeField] private bool isJumpButtonDown = false;

    private void Start()
    {
        groundCheckObj = GameObject.FindGameObjectWithTag("GroundCheck");
        characterName = GetComponent<ObjectTags>().characterName;
    }
    private void FixedUpdate()
    {
        GroundCheck();
        JumpInputCheck();
        jumpInput = Input.GetAxis(jumpAxis);
    }

    private bool GroundCheck()
    {
        // checks if the groundcheck is in a small radius of the Ground layer
        groundCheckBool = Physics.CheckSphere(groundCheckObj.transform.position, 0.5f, groundLayer);
        return groundCheckBool;
    }
    private void JumpInputCheck()
    {
        if (jumpInput > 0f && !isJumpButtonDown)
        {
            // Button pressed, perform action
            this.isJumpButtonDown = true;
            Jump();
        }

        if (jumpInput == 0f)
        {
            // Button released, reset the flag
            this.isJumpButtonDown = false;
        }
    }

    private void Jump()
    {



        if (characterName == "Kirby")
        {
            CanJumpMore = true;
        }

        if (groundCheckBool)
        {
            if (true)
            {
                CanDoubleJump = true;
                playerMovement.rb.velocity = new Vector3(playerMovement.rb.velocity.x, 1 * playerMovement.jumpPower, playerMovement.rb.velocity.z);
                if (CanDoubleJump)
                {
                    CanDoubleJump = false;
                    playerMovement.rb.velocity = new Vector3(playerMovement.rb.velocity.x, 1 * playerMovement.jumpPower, playerMovement.rb.velocity.z);

                }
            }
        }
    }

}