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
        bool isBelowTrans = playerHealth.wholeDamage < 100;

        float value = Map(
            playerHealth.wholeDamage,
            isBelowTrans ? 0 : playerHealth.MaxTransWholeDamage,
            isBelowTrans ? playerHealth.MaxTransWholeDamage : playerHealth.MaxDamage,
            0,
            1
        );
        Text.color = Color.Lerp(
            isBelowTrans ? initialColor : TransColor,
            isBelowTrans ? TransColor : EndColor,
            value
        );
    }

    float Map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }
}
