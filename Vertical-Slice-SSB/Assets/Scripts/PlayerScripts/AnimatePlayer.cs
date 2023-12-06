public class AnimatePlayer : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;
    private float xPos;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GameObject.FindWithTag("Player2").GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Vector3 lastPos = this.transform.position;

        if (xPos == this.gameObject.transform.position.x)
        {
            animator.SetBool("IsWalking", false);
            animator.speed = 1f;

        }
        else
        {
            animator.SetBool("IsWalking", true);
            animator.speed = 2f;

        }
        xPos = this.gameObject.transform.position.x;
    }
    public void setAnimation(string name, bool animationBool)
    {
        animator.SetBool(name, animationBool);
    }
    //resolve merge conflict
}
