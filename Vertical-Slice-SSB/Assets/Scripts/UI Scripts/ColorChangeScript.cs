using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ColorChangeScript : MonoBehaviour
{
    public TextMeshPro Text;
    public Color initialColor;  
    public Color maxColor;       
    public PlayerHealth playerHealth;

    
    void Start()
    {
       
        Text.color = initialColor;
    }

    void Update()
    {
        float normalizedHealth = Mathf.Clamp01(playerHealth.wholeDamage / playerHealth.maxWholeDamage);

       
        Text.color = Color.Lerp(initialColor, maxColor, normalizedHealth);
    }
}
