﻿using System.Collections;
using UnityEngine;

public class Charge : MonoBehaviour
{
    public float chargeSpeed = 2.0f;
    public float maxChargeTime = 3.0f;
    public float chargeTimeThreshold = 1.5f;

    private float currentChargeTime = 0.0f;
    private bool isCharging = false;

    [SerializeField] private DoDamage doDamage;
    [SerializeField] private float multiplier;
    [SerializeField] private GameObject attackColliderGO;
    private AnimatePlayer animatePlayer;
    public bool canAttack = true;
    [SerializeField] private GameObject FatalBlow;

    QuickAttack quickAttack;

    private void Start()
    {
        doDamage = GetComponent<DoDamage>();
        animatePlayer = GetComponentInChildren<AnimatePlayer>();
        quickAttack = GetComponent<QuickAttack>();
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.V))
        {
            if (currentChargeTime > 1.5f)
            {
                ResetAnimatorBool();
                Debug.Log("trigger charge atta");
                PerformChargeAttack();
            }
            else
            {
                HeavyAttack heavyAttack = GetComponent<HeavyAttack>();
                heavyAttack.DoAttack();
            }
        }
        if (Input.GetKey(KeyCode.V))
        {
            currentChargeTime += Time.deltaTime;
            if (currentChargeTime >= chargeTimeThreshold && !isCharging)
            {

                animatePlayer.playAnimation("ChargeUpAttack");
            }
        }
    }
    void PerformChargeAttack()
    {
        StartCoroutine(ActivateCollider());
        doDamage.IsAttacking(currentChargeTime);

        GameObject FatalBlowObj = Instantiate(FatalBlow, transform);
        //OnAnimationEnd.OnAniEnd += ;
        animatePlayer.animator.SetBool("ResumeChargeAttack", true);
        ResetAttackVariables();
        StartCoroutine(TransitionToNextAnimation());
    }
    IEnumerator TransitionToNextAnimation()
    {
        yield return new WaitForSeconds(0.5f); // Adjust the delay as needed
        animatePlayer.animator.SetBool("ResumeChargeAttack", false);
        ResetAttackVariables();
    }
    void ResetAttackVariables()
    {
        currentChargeTime = 0.0f;
        isCharging = false;
    }
    IEnumerator ActivateCollider()
    {
        attackColliderGO.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        attackColliderGO.SetActive(false);
    }
    void ResetAnimatorBool()
    {
        // Reset the animator bool here
        Debug.Log("ds");
        animatePlayer.animator.SetBool("ResumeChargeAttack", true);
    }
}
