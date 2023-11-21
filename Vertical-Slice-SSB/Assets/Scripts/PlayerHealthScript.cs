using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealthScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI DamageDisplay;


    public float damage;

    void Start()
    {
        damage = 0; //The amount of damage the player has taken
    }


    void Update()
    {
        DamageDisplay.text = damage.ToString() + "%";
        
    }



}
