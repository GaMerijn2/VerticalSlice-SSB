using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI DamageDisplay;


    public float damage;
    private int wholeDamage;

    void Start()
    {
        damage = 0; //The amount of damage the player has taken
    }


    void Update()
    {
        wholeDamage = (int)damage;
        DamageDisplay.text = wholeDamage.ToString() + "%";   
    }



}
