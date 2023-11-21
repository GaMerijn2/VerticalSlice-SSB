using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathWall : MonoBehaviour
{
    public Vector3 spawn = Vector3.zero;

    private void OnCollisionEnter(Collision collision)
    {
        
        
        
        
        if (collision.gameObject.CompareTag("Player"))
        {
            Lives livesScript = collision.gameObject.GetComponent<Lives>();
            if (livesScript != null)
            {
                livesScript.DecreaseLives();
            }
        }
    }
}
