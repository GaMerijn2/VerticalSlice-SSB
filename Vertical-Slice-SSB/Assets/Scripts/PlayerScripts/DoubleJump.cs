using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    [SerializeField] private float jumpAmountLeft = 5f;
    [SerializeField] private float jumpPower = 3.9f;
    [SerializeField] private float secondJumpPower; // asigned in the CheckCharacter()
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

    private AudioManager audioManager;
    private AudioSource audioSource;



    private int jumpCylce = 0;
    private int normalJumps = 2;
    private int extraJumps = 5;
    private float normalForce = 1f;

    [SerializeField] private PlayerContols controls;


    private void Start()
    {
        characterName = GetComponent<ObjectTags>().characterName;
        canJump = true;
        jumpPower = playerMovement.jumpPower;
        audioManager = GameObject.Find("JumpAudio").GetComponent<AudioManager>();
        audioSource = GameObject.Find("JumpAudio").GetComponent<AudioSource>();


    }
    private void Awake()
    {
        controls = new PlayerContols();
        controls.Gameplay.Jump.performed += ctx => normalJump(1);
    }
    private void FixedUpdate()
    {
        GroundCheck();
        JumpInputCheck();
        jumpInput = Input.GetAxis(jumpAxis); // gets the input for each character
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
            this.isJumpButtonDown = true;
            Jump();
            // Button pressed, perform action
        }

        if (jumpInput == 0f)
        {
            // Button released, reset the flag
            this.isJumpButtonDown = false;
        }
    }

    private void Jump()
    {
        // checks the unique effects of the characters
        CheckCharacter();

        // the first jump, when you're standing on the ground
        if (groundCheckBool)
        {
            extraJumps = 5;
            CanDoubleJump = true;
            normalJump(jumpPower);
            PlayjumpSound();
            audioSource.pitch = 1f;
        }
        // the second jump from the ground
        else if (CanDoubleJump)
        {
            CanDoubleJump = false;
            normalJump(jumpPower);
            PlayjumpSound();
        }
        // checks if the character can jump more then 2 times
        else if (CanJumpMore)
        {
            //checks how many jumps it can do before stopping
            if (extraJumps > 0)
            {
                extraJumps--; // removes 1 jump from the max jumps
                Debug.Log(extraJumps + " Jumps left.");
                audioSource.pitch += 0.04f;
                PlayjumpSound();
                normalJump(secondJumpPower);
            }
            CanJumpMore = false;
        }
    }

    private void normalJump(float jumpPower)
    {
        // default jump with assignable jumpPower
        playerMovement.rb.velocity = new Vector3(playerMovement.rb.velocity.x, 1 * jumpPower, playerMovement.rb.velocity.z);
    }

    private void CheckCharacter()
    {
        // checks the characters names
        if (characterName == "Kirby" || characterName == "Jigglypuff")
        {
            CanJumpMore = true; // if the characers names are like above, set it so they can jump more then twice
            if (characterName == "Kirby")
            {
                secondJumpPower = playerMovement.jumpPower / 1.5f; // secondairy jump power for Kirby
            }
            if (characterName == "Jigglypuff")
            {
                secondJumpPower = playerMovement.jumpPower / 1.5f; // secondairy jump power for Jigglypuff
            }
        }
    }

    private void PlayjumpSound()
    {
        audioManager.PlayRandomAudio();

    }
}
