using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KirbyDeathWall : MonoBehaviour
{
    public Vector3 spawn = Vector3.zero;
    public bool isDamaging = false;
    public float resetDamageDelay = 0.25f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player1"))
        {
            KirbysLives livesScript = collision.gameObject.GetComponent<KirbysLives>();
            if (livesScript != null && !isDamaging)
            {
                livesScript.DecreaseLives();
                isDamaging = true;
                collision.gameObject.transform.position = spawn;
                StartCoroutine(ResetDamageAfterDelay());
            }
        }
    }

    IEnumerator ResetDamageAfterDelay()
    {
        yield return new WaitForSeconds(resetDamageDelay);
        isDamaging = false;
    }
}
