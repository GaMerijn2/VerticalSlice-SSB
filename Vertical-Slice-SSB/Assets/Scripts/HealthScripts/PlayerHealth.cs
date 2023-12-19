using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI DamageDisplay;


    public float damage;
    public int wholeDamage;
    public int MaxTransWholeDamage;
    public int MaxDamage;

    public void Awake()
    {
        MaxTransWholeDamage = 100;
        MaxDamage = 200;
    }

    void Start()
    {
        damage = 0;
    }


    void Update()
    {
        wholeDamage = (int)damage;
        DamageDisplay.text = wholeDamage.ToString() + "%";
    }
}
