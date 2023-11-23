using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDamage : MonoBehaviour
{

    [SerializeField] private float Multiplier;
    private bool IsAttackingvar = false;

    void Start()
    {
        
    }

    void Update()
    {
        
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
            IsAttackingvar = false;
        }
        else
        {
            IsAttackingvar = false;
        }
    }
}
