﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDamage : MonoBehaviour
{

    private float Multiplier;
    private bool IsAttackingvar = false;


    public void IsAttacking(float multiplier)
    {
        Multiplier = multiplier;
        IsAttackingvar = true;
    }

    private Collision OnTriggerStay(Collider collision)
    {
        if (IsAttackingvar == true && (collision.CompareTag("Player1") || collision.CompareTag("Player2")))
        {
            TakeDamage takedamagevar = collision.GetComponent<TakeDamage>();
            takedamagevar.TakeDamageFun(3, Multiplier);
            IsAttackingvar = false;
            //DoKnockback(Health.damage, collision.GetComponent<FlipPlayer>().isFacingRight);
            return Collision;
        }
        else
        {
            IsAttackingvar = false;
        }
    }
}
