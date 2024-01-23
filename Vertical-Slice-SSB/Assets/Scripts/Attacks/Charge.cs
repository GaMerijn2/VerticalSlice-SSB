using UnityEngine;

public class Charge : MonoBehaviour
{
    [SerializeField] private float damageup;
    public bool isCharging;
    public bool canCharge;
    [SerializeField] private int wichPlayer;
    [SerializeField] private KeyCode key;
    [SerializeField] private float multiplier;
    [SerializeField] private float ChargeTime;
    [SerializeField] private float ChargeSpeed;
    private TakeDamage damage; // Declare the variable at the class level

    // Start is called before the first frame update
    void Start()
    {
        if (wichPlayer == 2)
        {
            key = KeyCode.P;
        }

        if (wichPlayer == 1)
        {
            key = KeyCode.V;
        }

        damage = GetComponent<TakeDamage>();
    }
    void Update()
    {
        if (Input.GetKey(key) && ChargeTime < 2)
        {
            isCharging = true;
            canCharge = false;
            ChargeTime += Time.deltaTime * ChargeSpeed;
            multiplier += 0.2f * Time.deltaTime;
        }
        if (Input.GetKeyUp(key) && ChargeTime > 2)
        {
            ChargeTime = 0;
            ReleaseCharge();
            multiplier = 1;
        }
    }

    private void ReleaseCharge()
    {
        isCharging = false;
        ChargeTime = 0;
        if (damage != null)
        {
            damage.TakeDamageFun(damageup, multiplier);
        }
    }
}
