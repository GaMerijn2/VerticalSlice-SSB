using System.Collections;
using UnityEngine;

public class QuickAttack : MonoBehaviour
{
    [SerializeField] private int Player;
    [SerializeField] private DoDamage doDamage;
    [SerializeField] private float multiplier;
    [SerializeField] private GameObject attackColliderGO;
    public Animator animator;
    private KeyCode QuickAttackKeyCode;
    private Charge charge;
    [SerializeField] private AudioManager audioManagerVoice;
    [SerializeField] private AudioManager audioManagerFx;

    //player 1 controlls: "C" for quick attack and "V" for heavy attack

    //player 2 controlls: "O" for quick attack and "P" for heavy attack 

    void Start()
    {
        if (Player != 1 && Player != 2)
        {
            Debug.Log("Player incorectly assigned");
            Application.Quit();
        }

        if (Player == 1)
        {
            QuickAttackKeyCode = KeyCode.C;
        }
        if (Player == 2)
        {
            QuickAttackKeyCode = KeyCode.O;
        }
        animator = GetComponentInChildren<Animator>();
        charge = GetComponent<Charge>();

    }
    void Update()
    {
        DoAttack();
    }
    public void DoAttack()
    {
        if ((Player == 1 || Player == 2) && Input.GetKeyDown(QuickAttackKeyCode))
        {
            StartCoroutine(ActivateCollider());
            Attack();
            doDamage.IsAttacking(multiplier);
        }
    }
    private void Attack()
    {
        //play animation, gameartist
        audioManagerVoice.PlayRandomAudio();
        audioManagerFx.PlayRandomAudio();
        animator.Play("LAttack");
        // Debug.Log("ATTACK!");

    }


    IEnumerator ActivateCollider()
    {
        attackColliderGO.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        attackColliderGO.SetActive(false);
    }
}
