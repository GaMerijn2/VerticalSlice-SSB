using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyAttack : MonoBehaviour
{
    [SerializeField] private int Player;
    [SerializeField] private DoDamage doDamage;
    [SerializeField] private float multiplier;
    private KeyCode HeavyAttackKeyCode;

    //player 1 controlls: "C" for quick attack and "V" for heavy attack

    //player 2 controlls: "O" for quick attack and "P" for heavy attack 

    void Start()
    {
        if(Player != 1 && Player != 2)
        {
            Debug.Log("Player incorectly assigned");
            Application.Quit();
        }

        if (Player == 1)
        {
            HeavyAttackKeyCode = KeyCode.V;
        }
        if (Player == 2)
        {
            HeavyAttackKeyCode = KeyCode.P;
        }

    }

    void Update()
    {
        if ((Player == 1 || Player == 2) && Input.GetKeyDown(HeavyAttackKeyCode))
        {
            Attack();
            doDamage.IsAttacking(multiplier);
        }
    }

    private void Attack()
    {
        //play animation, gameartist
        Debug.Log("HEAVY_ATTACK!");

    }

}
