using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI DamageDisplay;


    public float damage;
    public int wholeDamage;
    public int maxWholeDamage;

    void Start()
    {
        damage = 0; //The amount of damage the player has taken
        maxWholeDamage = 400;
    }


    void Update()
    {
        wholeDamage = (int)damage;
        DamageDisplay.text = wholeDamage.ToString() + "%";   
        if(wholeDamage> maxWholeDamage)
        {
            damage = 400;
        }
    }



}
