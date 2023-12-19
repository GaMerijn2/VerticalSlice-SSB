using System.Collections;
using UnityEngine;

public class Deathwall : MonoBehaviour
{
    public GameObject spawnPos;
    public bool isDamaging = false;
    public float resetDamageDelay = 0.25f;

    public void OnCollisionEnter(Collision collision)
    {
        Lives lives = collision.gameObject.GetComponent<Lives>();
        HandlePlayerCollision(collision, lives);
    }

    private void HandlePlayerCollision(Collision collision, Lives lives)
    {
        if (lives != null && !isDamaging)
        {
            lives.DecreaseLives();
            isDamaging = true;
            collision.gameObject.transform.position = spawnPos.transform.position;
            StartCoroutine(ResetDamageAfterDelay());
        }
    }

    IEnumerator ResetDamageAfterDelay()
    {
        yield return new WaitForSeconds(resetDamageDelay);
        isDamaging = false;
    }
}
