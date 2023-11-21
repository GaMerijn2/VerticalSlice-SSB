using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageScript : MonoBehaviour
{
    public string keybind; //Assign keybind in inspector
    [SerializeField] PlayerHealthScript Health; //Player health
    void TakeDamage(float damageAmount) //Take damage function
    {
        Health.damage = Health.damage + damageAmount; //Adds damage to the player health
        Debug.Log(Health.damage); //Console log of the amount of damage the player has taken
    }

    private void Update() //Player takedamage function test
    {
        if (Input.GetKeyDown(keybind))
        {
            TakeDamage(5); 
        }
    }

}
