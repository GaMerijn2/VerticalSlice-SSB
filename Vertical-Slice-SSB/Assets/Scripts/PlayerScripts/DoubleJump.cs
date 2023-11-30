using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Drawing;
using UnityEngine;
using UnityEngine.XR;

public class DoubleJump : MonoBehaviour
{
    [SerializeField] private float secondJumpPower = 1f;
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


    private int jumpCylce = 0;
    private int normalJumps = 2;
    private int extraJumps = 5;
    private int normalForce = 1;


    private void Start()
    {
        characterName = GetComponent<ObjectTags>().characterName;
        canJump = true;
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

        if (jumpCylce == 0 && groundCheckBool)
        {

        }
        else if (jumpCylce > 0 && jumpCylce < 4)
        {

        }
        else if (jumpCylce == 4)
        {
            jumpCylce = 0;
        }

        if (jumpInput > 0f && !isJumpButtonDown)
        {
            if (jumpCylce > normalJumps)
            {
                if (jumpCylce > extraJumps)
                {
                    Jump(normalForce / 2);
                }
            }
            else
            {
                Jump(normalForce);
            }
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

    private void Jump( int force)
    {
        jumpCylce++;
        // First jump from ground
        if (groundCheckBool)
        {
            CanDoubleJump = true;
            checkCharacter();
            normalJump(playerMovement.jumpPower);
        }
    }

    private void DoJump()
    {
        canJump = true;
        normalJump(secondJumpPower);
    }

    private void normalJump(float jumpPower)
    {
        playerMovement.rb.velocity = new Vector3(playerMovement.rb.velocity.x, 1 * jumpPower, playerMovement.rb.velocity.z);
    }

    private void checkCharacter()
    {
        if (characterName == "Kirby" || characterName == "Jigglypuff")
        {
            CanJumpMore = true;
            if (characterName == "Kirby")
            {
                secondJumpPower = playerMovement.jumpPower / 2;
            }
        }
    }
}