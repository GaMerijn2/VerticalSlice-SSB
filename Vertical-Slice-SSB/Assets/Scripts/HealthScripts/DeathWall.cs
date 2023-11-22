using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathWall : MonoBehaviour
{
    public Vector3 spawn = Vector3.zero;
    private bool isDamaging = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Lives livesScript = collision.gameObject.GetComponent<Lives>();
            if (livesScript != null && !isDamaging)
            {
                livesScript.DecreaseLives();
                isDamaging = true;
                collision.gameObject.transform.position = spawn;
                Invoke("ResetDamage", 0.25f);
            }
        }
    }

    void ResetDamage()
    {
        isDamaging = false;
    }
}
