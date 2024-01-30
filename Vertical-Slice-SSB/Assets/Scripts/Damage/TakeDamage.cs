using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public string keybind; //Assign keybind in inspector
    [SerializeField] PlayerHealth Health; //Player health
    [SerializeField] private AudioManager hitSound;
    public void TakeDamageFun(float damageAmount, float multiplier) //Take damage function
    {
        Health.damage += damageAmount * multiplier; //Adds damage to the player health
        Debug.Log(Health.damage);
        hitSound.GetComponent<AudioManager>().PlayRandomAudio();
    }
}
