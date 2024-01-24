using System.Collections;
using UnityEngine;

public class Dash : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private AnimatePlayer animatePlayer;

    [SerializeField] private bool canDash;
    [SerializeField] public bool isDashing;
    [SerializeField] private float dashingPower;
    [SerializeField] private float dashingTime;
    [SerializeField] private float dashingCooldown;

    [SerializeField] private TrailRenderer trailRenderer;
    private ObjectTags objectTags;
    [SerializeField] private KeyCode dashInputKey;

    [SerializeField] private AudioSource[] DashSound;
    private void Start()
    {
        canDash = true;
        rb = transform.GetComponent<Rigidbody>();
        objectTags = transform.GetComponent<ObjectTags>();

        if (objectTags.name == "Kirby")
        {
            dashInputKey = KeyCode.I;
        }
        else if (objectTags.name == "JigglyPuff")
        {
            dashInputKey = KeyCode.B;
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(dashInputKey) && canDash)
        {
            Debug.Log("dash");
            StartCoroutine(DoDash());
        }
    }
    private IEnumerator DoDash()
    {
        canDash = false;
        isDashing = true;
        //DashSound[0].Play();
        rb.useGravity = false;
        float originalDrag = rb.drag;
        rb.drag = 0f;
        animatePlayer.playAnimation("Dash");

        rb.velocity = new Vector3(transform.localScale.x * -dashingPower, 0f, -dashingPower);
        trailRenderer.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        //DashSound[1].Play();
        trailRenderer.emitting = false;
        isDashing = false;
        rb.useGravity = true;
        rb.drag = originalDrag;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}
