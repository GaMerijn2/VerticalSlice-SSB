using UnityEngine;
public class AnimatePlayer : MonoBehaviour
{
    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void setAnimation(string name, bool animationBool)
    {
        animator.SetBool(name, animationBool);
    }
    public void playAnimation(string name)
    {
        animator.Play(name);
    }
}
