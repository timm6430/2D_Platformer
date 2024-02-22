﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public FiniteStateMachine stateMachine;
    public D_Entity entityData;
    public Rigidbody2D rb {get; private set;}
    public Animator anim {get; private set;}
    public GameObject aliveGO {get; private set;}

    private Vector2 velocityWorkSpace;
    public AnimationToStateMachine atsm {get; private set;}

    public int facingDirection {get; private set;}
    public int lastDamageDirection {get; private set;}
    private float currentHealth;

    protected bool isDead;

    [SerializeField]
    private Transform wallCheck;
    [SerializeField]
    private Transform ledgeCheck;
    [SerializeField]
    private Transform playerCheck;
    [SerializeField]
    private Transform groundCheck;

    public virtual void Start()
    {
        facingDirection = 1;
        currentHealth = entityData.maxHealth;

        aliveGO = transform.Find("Alive").gameObject;
        rb = aliveGO.GetComponent<Rigidbody2D>();
        anim = aliveGO.GetComponent<Animator>();
        stateMachine = new FiniteStateMachine();
        atsm = aliveGO.GetComponent<AnimationToStateMachine>();
    }

    public virtual void Update()
    {
        stateMachine.currentState.LogicUpdate();
    }

    public virtual void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
    }

    public virtual void SetMovingVelocity (float velocity)
    {
        velocityWorkSpace.Set(facingDirection * velocity, rb.velocity.y);
        rb.velocity = velocityWorkSpace;
    }

    public virtual void SetActionVelocity(float velocity, Vector2 angle, int direction)
    {
      angle.Normalize();
      velocityWorkSpace.Set(angle.x * velocity * direction, angle.y * velocity);
      rb.velocity = velocityWorkSpace;
    }

    public virtual bool checkWall ()
    {
        return Physics2D.Raycast(wallCheck.position, aliveGO.transform.right, entityData.wallCheckDistacne, entityData.whatIsGround);
    }

    public virtual bool checkLedge ()
    {
        return Physics2D.Raycast(ledgeCheck.position, Vector2.down, entityData.ledgeCheckDistance, entityData.whatIsGround);
    }

    public virtual bool CheckGround()
    {
      return Physics2D.OverlapCircle(groundCheck.position, entityData.groundCheckRadius, entityData.whatIsGround);
    }

    public virtual bool CheckPlayerInMinAgroRange()
    {
        return Physics2D.Raycast(playerCheck.position, aliveGO.transform.right, entityData.minAgroDistance, entityData.whatIsPlayer);
    }

    public virtual bool CheckPlayerInMaxAgroRange()
    {
        return Physics2D.Raycast(playerCheck.position, aliveGO.transform.right, entityData.maxAgroDistance, entityData.whatIsPlayer);
    }

    public virtual bool CheckPlayerInCloseRangeAction()
    {
      return Physics2D.Raycast(playerCheck.position, aliveGO.transform.right, entityData.closeRangeActionDistance, entityData.whatIsPlayer);
    }

    public virtual void Damage(AttackDetails attackDetails)
    {
      currentHealth -= attackDetails.damageAmount;
      if(attackDetails.position.x > aliveGO.transform.position.x)
      {
        lastDamageDirection = -1;
      }
      else
      {
          lastDamageDirection = 1;
      }

      if(currentHealth <= 0)
      {
        isDead = true;
      }
    }

    public virtual void Flip()
    {
        facingDirection *= -1;
        aliveGO.transform.Rotate(0f, 180f, 0f);
    }

    public virtual void OnDrawGizmos() 
    {
      Gizmos.DrawLine(wallCheck.position, wallCheck.position + (Vector3)(Vector2.right * facingDirection * entityData.wallCheckDistacne));
      Gizmos.DrawLine(ledgeCheck.position, ledgeCheck.position + (Vector3)(Vector2.down * entityData.ledgeCheckDistance));

      Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * entityData.closeRangeActionDistance), 0.2f);
      Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * entityData.minAgroDistance), 0.2f);
      Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * entityData.maxAgroDistance), 0.2f);

    }

}