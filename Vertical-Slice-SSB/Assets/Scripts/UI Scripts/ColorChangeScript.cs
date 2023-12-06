using TMPro;
using UnityEngine;

public class ColorChangeScript : MonoBehaviour
{
    public TMP_Text Text;
    public Color initialColor;
    public Color TransColor;
    public Color EndColor;
    public PlayerHealth playerHealth;

    void Start()
    {
        Text.color = initialColor;
    }

    void Update()
    {
        float map(float s, float a1, float a2, float b1, float b2)
        {
            return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
        }

        float value = map(playerHealth.wholeDamage, 0, playerHealth.MaxTransWholeDamage, 0, 1);

        Text.color = Color.Lerp(initialColor, TransColor, value);
        if (Text.color == TransColor)
        {
            //Debug.Log("Text color lerp");
            float map2(float s, float a1, float a2, float b1, float b2)
            {
                return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
            }

            float value2 = map2(playerHealth.MaxTransWholeDamage, 0, playerHealth.MaxDamage, 0, 1);
            Text.color = Color.Lerp(initialColor, EndColor, value2);
        }
    }
}
