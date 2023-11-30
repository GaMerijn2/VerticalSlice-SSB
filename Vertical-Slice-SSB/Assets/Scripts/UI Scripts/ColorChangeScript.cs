using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ColorChangeScript : MonoBehaviour
{
    public TextMeshPro Text;
    public Color initialColor;   // Starting color of the text
    public Color maxColor;       // Color when the player has taken maximum damage
    public PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        // Set the initial color of the text
        Text.color = initialColor;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the normalized health value (between 0 and 1)
        float normalizedHealth = Mathf.Clamp01(playerHealth.wholeDamage / playerHealth.maxWholeDamage);

        // Interpolate between initialColor and maxColor based on normalizedHealth
        Text.color = Color.Lerp(initialColor, maxColor, normalizedHealth);
    }
}
