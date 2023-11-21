using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathWall : MonoBehaviour
{
    public Vector3 spawn = Vector3.zero;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "DeathWall")
        {

            // Reset de position naar (0, 0, 0)
            transform.position = spawn;
        }
    }
}
