using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] PlayerHealth Health;
    [SerializeField] GameObject opponent;
    [SerializeField] DoDamage dodamage;
    public float direction;

    private void Update()
    {
        if(opponent.GetComponent<FlipPlayer>().isFacingRight == true)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }

        collision.GetComponent<PlayerMovement>().rb.AddForce(Vector3.up * direction * (1 + (playerHealth.damage / 100 * 7)), ForceMode.VelocityChange);

        collision.GetComponent<PlayerMovement>().rb.AddForce(Vector3.right * direction * (7 + (playerHealth.damage * 1.2f)), ForceMode.Impulse);

    }


}
