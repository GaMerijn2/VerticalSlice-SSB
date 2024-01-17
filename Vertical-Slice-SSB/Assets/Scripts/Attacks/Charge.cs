using System.Collections;
using UnityEngine;

public class Charge : MonoBehaviour
{
    public float chargeSpeed = 2.0f;
    public float maxChargeTime = 3.0f;

    private float currentChargeTime = 0.0f;
    private bool isCharging = false;

    [SerializeField] private DoDamage doDamage;
    [SerializeField] private float multiplier;
    [SerializeField] private GameObject attackColliderGO;
    private AnimatePlayer animatePlayer;

    private void Start()
    {
        doDamage = GetComponent<DoDamage>();
        animatePlayer = GetComponentInChildren<AnimatePlayer>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.V))
        {
            isCharging = true;
            currentChargeTime += Time.deltaTime;

            // Limit the charge time
            currentChargeTime = Mathf.Clamp(currentChargeTime, 0.0f, maxChargeTime);
        }
        else if (isCharging)
        {
            // Perform the attack based on the charge level
            PerformChargeAttack();

            // Reset charge variables
            currentChargeTime = 0.0f;
            isCharging = false;
        }
    }

    void PerformChargeAttack()
    {
        // Implement your charge attack logic here
        StartCoroutine(ActivateCollider());
        doDamage.IsAttacking(multiplier);
        float chargeLevel = currentChargeTime / maxChargeTime;

        // Adjust attack strength or trigger specific attack animations based on chargeLevel
        // Example: characterAnimator.SetTrigger("ChargeAttack");

        // Reset any other necessary variables
    }
    private void Attack()
    {
        //play animation, gameartist
        animatePlayer.playAnimation("ChargeAttack");
        Debug.Log("CHARGE_ATTACK!");
    }

    IEnumerator ActivateCollider()
    {
        attackColliderGO.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        attackColliderGO.SetActive(false);
    }
}

