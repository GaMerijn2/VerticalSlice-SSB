using UnityEngine;

public class DoDamage : MonoBehaviour
{

    private float Multiplier;
    private bool IsAttackingvar = false;
    private PlayerHealth playerHealth;
    private Rigidbody rb;
    private float direction;
    // private knockback knockback;
    Transform SmokeParticle;
    [SerializeField] private Transform[] HitEffects;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    public void IsAttacking(float multiplier)
    {
        Multiplier = multiplier;
        IsAttackingvar = true;
    }

    private void OnTriggerStay(Collider collision)
    {
        if (IsAttackingvar == true && (collision.CompareTag("Player1") || collision.CompareTag("Player2")))
        {
            TakeDamage takedamagevar = collision.GetComponent<TakeDamage>();
            takedamagevar.TakeDamageFun(3, Multiplier);


            playerHealth = collision.GetComponent<PlayerHealth>();
            bool knockbackDirection = gameObject.GetComponent<FlipPlayer>().isFacingRight;

            if (knockbackDirection)
            {
                direction = -1;
            }
            else if (!knockbackDirection)
            {
                direction = 1;
            }
            collision.GetComponent<PlayerMovement>().rb.AddForce(Vector3.up * direction * (1 + (playerHealth.damage / 100 * 7)), ForceMode.VelocityChange);

            collision.GetComponent<PlayerMovement>().rb.AddForce(Vector3.right * direction * (7 + (playerHealth.damage * 1.2f)), ForceMode.Impulse);
            int RandomHitSprite = Random.Range(0, HitEffects.Length);
            Debug.Log("PArticle");
            Vector3 hitEnemyPos = new Vector3(collision.transform.position.x, collision.transform.position.y);
            var go = Instantiate(HitEffects[RandomHitSprite]);
            go.transform.position = hitEnemyPos;
            AnimatePlayer enemyAnimator = collision.GetComponentInChildren<AnimatePlayer>();
            enemyAnimator.playAnimation("Hit");

            // SmokeParticle = collision.transform.Find("SmokeParticle");
            // SmokeParticle.gameObject.SetActive(true);
            // Invoke(nameof(resetParticle), 2f);
            //knockback.AddKnockback(playerHealth.damage, knockbackDirection) // +1 voor constant knockback


            IsAttackingvar = false;
        }
        else
        {
            IsAttackingvar = false;
        }
    }
    //private void resetParticle()
    //{
    // SmokeParticle.gameObject.SetActive(false);
    //}
}
