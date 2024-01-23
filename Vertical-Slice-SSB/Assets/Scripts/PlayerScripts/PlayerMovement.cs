using System.Reflection;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Movement Objects
    public Rigidbody rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] public float jumpPower;

    private float horizontalInput;

    [SerializeField] private string horizontalInputAxis;
    [SerializeField] private Dash dash;

    [SerializeField] private AnimatePlayer animatePlayer;

    [SerializeField] private RandomAudioClip jumpClips;
    [SerializeField] private AudioSource audioSource;

    private float xPos;
    private Vector3 lastPos;

    PlayerContols controls;
    Vector2 move;
    ParameterInfo ctx1;

    //private float verticalInput;

    void Start()
    {
        FindPlayerTag();

        OnAnimationEnd.OnAniEnd += Twest;

    }

    private void Twest()
    {
        Debug.Log("TWESTTTTT!!!");
    }
    private void FindPlayerTag()
    {
        rb = transform.GetComponent<Rigidbody>();
        audioSource = gameObject.GetComponent<AudioSource>();
        animatePlayer = GameObject.Find("kirby blender animatie lopen met riig fbx").GetComponent<AnimatePlayer>();

    }
    private void Awake()
    {
        controls = new PlayerContols();
        // controls.Gameplay.HorizontalMove.performed += ctx => move = ctx.ReadValue<Vector2>();
        //controls.Gameplay.HorizontalMove.canceled += ctx1 => move = Vector2.zero;

        Input.GetJoystickNames();

    }
    private void Update()
    {
        WalkAnimation();
        //Debug.Log(ctx1);
    }

    void FixedUpdate()
    {
        //Physics.IgnoreLayerCollision(6, 6, true);
        if (dash != null)
        {
            if (dash.isDashing)
            {
                return;
            }
        }

        horizontalInput = Input.GetAxis(horizontalInputAxis);
        Move();

    }

    private void Move()
    {
        if (rb != null) // checks if the rigidbody isn't null
        {
            //Moves the player Left and Right based on the input
            Vector3 moveInput = new Vector3(horizontalInput, rb.velocity.y, rb.velocity.z);
            rb.MovePosition(transform.position + moveInput * Time.deltaTime * moveSpeed);


            // Controller movement
            move = new Vector2(move.x, move.y) * Time.deltaTime * moveSpeed;
            // rb.MovePosition(move);


            Vector3 lasPos = transform.position;
            float speed = (transform.position - lasPos).magnitude / Time.deltaTime;

        }
        else if (rb == null) // checks if the rigidbody is null
        {
            Debug.LogError("Rigidbody is Null!"); // logs a error message to the console
        }





    }
    private void WalkAnimation()
    {
        xPos = this.gameObject.transform.position.x;
        if (xPos == lastPos.x)
        {
            animatePlayer.setAnimation("IsWalking", false);
            animatePlayer.animator.speed = 2f;
        }
        else
        {
            animatePlayer.setAnimation("IsWalking", true);
            animatePlayer.animator.speed = 1f;//animatie snel afmaken ivm has exit time
        }
        lastPos = this.transform.position;
    }
}
