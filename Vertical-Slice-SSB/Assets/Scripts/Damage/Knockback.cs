using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    [SerializeField] PlayerHealth health;
    [SerializeField] Rigidbody rb;
    [SerializeField] 
   void TakeKnockback(Vector3 direction, float health)
    {
        rb.AddForce(direction, ForceMode.Impulse);
    }
}
