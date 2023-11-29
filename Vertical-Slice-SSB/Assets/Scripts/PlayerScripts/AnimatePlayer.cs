using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatePlayer : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;
    private GameObject player;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GameObject.FindWithTag("Player2").GetComponent<Rigidbody>();
    }
    private void Update()
    {
        float animVelocity = rb.velocity.magnitude;
        animator.SetFloat("Velocity", animVelocity);
        Debug.Log("Velocity: " + animVelocity + ".");
    }
}
