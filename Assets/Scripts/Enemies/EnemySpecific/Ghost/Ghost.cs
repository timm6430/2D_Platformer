using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Entity
{
    public Ghost_IdleState idleState {get; private set;}
    public Ghost_MoveState moveState {get; private set;}
    public Ghost_PlayerDetectedState playerDetectedState {get; private set;}
    public Ghost_ChaseState chaseState {get; private set;}
    public Ghost_LookForPlayerState lookForPlayerState {get; private set;}
    public Ghost_MeleeAttackState meleeAttackState {get; private set;}
    public Ghost_HurtState hurtState {get; private set;}
    public Ghost_DeadState deadState {get; private set;}

    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_MoveState moveStateData;
    [SerializeField]
    private D_PlayerDetected playerDetectedStateData;
    [SerializeField]
    private D_ChaseState chaseStateData;
    [SerializeField]
    private D_LookForPlayerState lookForPlayerStateData;
    [SerializeField]
    private D_MeleeAttack meleeAttackStateData;
    [SerializeField]
    private Transform meleeAttackPosition;
    [SerializeField]
    private D_HurtState hurtStateData;
    [SerializeField]
    private D_DeadState deadStateData;

    public override void Start()
    {
        base.Start();
        moveState = new Ghost_MoveState(this, stateMachine, "move", moveStateData, this);
        idleState = new Ghost_IdleState(this, stateMachine, "idle", idleStateData, this);
        playerDetectedState = new Ghost_PlayerDetectedState(this, stateMachine, "playerDetected", playerDetectedStateData, this);
        chaseState = new Ghost_ChaseState(this, stateMachine, "chase", chaseStateData, this);
        lookForPlayerState = new Ghost_LookForPlayerState(this, stateMachine, "lookForPlayer", lookForPlayerStateData, this);
        meleeAttackState = new Ghost_MeleeAttackState(this, stateMachine, "meleeAttack", meleeAttackPosition, meleeAttackStateData, this);
        hurtState = new Ghost_HurtState(this, stateMachine, "hurt", hurtStateData, this);
        deadState = new Ghost_DeadState(this, stateMachine, "dead", deadStateData, this);

        stateMachine.Initialize(moveState);
    }

    public override void OnDrawGizmos()
    {
      base.OnDrawGizmos();

      Gizmos.DrawWireSphere(meleeAttackPosition.position, meleeAttackStateData.attackRadius);
    }

    public override void Damage(AttackDetails attackDetails)
    {
      base.Damage(attackDetails);
      stateMachine.ChangeState(hurtState);

      if(isDead)
      {
        stateMachine.ChangeState(deadState);
      }
    }
}
