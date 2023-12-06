﻿using UnityEngine;

public class QuickAttack : MonoBehaviour
{
    [SerializeField] private int Player;
    [SerializeField] private DoDamage doDamage;
    [SerializeField] private float multiplier;
    public Animator animator;
    private KeyCode QuickAttackKeyCode;

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

    }
    void Update()
    {
        if (Input.GetKeyDown(QuickAttackKeyCode))
        {
            Attack();
            doDamage.IsAttacking(multiplier);
        }
    }




    private void Attack()
    {
        //play animation, gameartist
        animator.Play("LAttack");

        Debug.Log("ATTACK!");

    }
}
