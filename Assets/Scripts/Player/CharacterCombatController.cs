using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCombatController : MonoBehaviour
{
    [SerializeField]
    private bool combatEnabled;
    [SerializeField]
    private float inputTimer, swordAttackRadius, swordAttackDamage = 1f;
    [SerializeField]
    private Transform swordAttackHitBoxPos;
    [SerializeField]
    private LayerMask whatisDamageable;

    private bool gotInput, isAttacking;
    private float lastInputTime = Mathf.NegativeInfinity;

    private AttackDetails attackDetails;
    private CharacterController2D CC;
    private CharacterStats CS;


    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("canAttack", combatEnabled);
        CC = GetComponent<CharacterController2D>();
        CS = GetComponent<CharacterStats>();
    }
    private void Update()
    {
        CheckCombatInput();
        CheckAttacks();
    }
    
    private void CheckCombatInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (combatEnabled)
            {
                gotInput = true;
                lastInputTime = Time.time;
            }
        }
    }

    private void CheckAttacks()
    {
        if (gotInput)
        {
            //Perform attack
            if (!isAttacking)
            {
                gotInput = false;
                isAttacking = true;
                anim.SetBool("swordAttack", true);
                anim.SetBool("isAttacking", isAttacking);
            }
        }
        if (Time.time >= lastInputTime + inputTimer)
        {
            //wait for new input
            gotInput = false;
        }
    }

    private void CheckAttackHitBox()
    {
        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(swordAttackHitBoxPos.position, swordAttackRadius, whatisDamageable);

        attackDetails.damageAmount = swordAttackDamage;
        attackDetails.position = transform.position;

        foreach (Collider2D collider in detectedObjects)
        {
            collider.transform.parent.SendMessage("Damage", attackDetails);
        }
    }

    private void FinishSwordAttack()
    {
        isAttacking = false;
        anim.SetBool("isAttacking", isAttacking);
        anim.SetBool("swordAttack", false);
    }

    private void Damage(AttackDetails attackDetails)
    {
      int direction;
      CS.DecreaseHealth(attackDetails.damageAmount);
      if (attackDetails.position.x < transform.position.x)
      {
        direction = 1;
      }
      else
      {
        direction = -1;
      }

      CC.Knockback(direction);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(swordAttackHitBoxPos.position, swordAttackRadius);
    }
}
