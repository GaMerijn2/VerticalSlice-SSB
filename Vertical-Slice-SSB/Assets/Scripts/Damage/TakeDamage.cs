using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public string keybind; //Assign keybind in inspector
    [SerializeField] PlayerHealth Health; //Player health
    public void TakeDamageFun(float damageAmount, float multiplier) //Take damage function
    {
        Health.damage = Health.damage + damageAmount * multiplier; //Adds damage to the player health
    }

    private void Update() //Player takedamage function test
    {
        //if (Input.GetKeyDown(keybind))
        //{
            //TakeDamageFun(5); 
        //}
    }

}