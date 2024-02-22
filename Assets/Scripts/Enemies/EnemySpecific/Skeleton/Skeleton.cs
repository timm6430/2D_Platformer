using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Entity
{
    public Skeleton_IdleState idleState {get; private set;}
    public Skeleton_MoveState moveState {get; private set;}
    public Skeleton_PlayerDetectedState playerDetectedState {get; private set;}
    public Skeleton_LookForPlayerState lookForPlayerState {get; private set;}
    public Skeleton_HurtState hurtState {get; private set;}
    public Skeleton_DeadState deadState {get; private set;}
    public Skeleton_DodgeState dodgeState {get; private set;}
    public Skeleton_RangeAttackState rangeAttackState {get; private set;}

    [SerializeField]
    private D_MoveState moveStateData;
    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_PlayerDetected playerDetectedStateData;
    [SerializeField]
    private D_LookForPlayerState lookForPlayerStateData;
    [SerializeField]
    private D_HurtState hurtStateData;
    [SerializeField]
    private D_DeadState deadStateData;
    [SerializeField]
    public D_DodgeState dodgeStateData;
    [SerializeField]
    private D_RangeAttackState rangeAttackData;

    [SerializeField]
    private Transform rangeAttackPosition;

    public override void Start()
    {
        base.Start();

        moveState = new Skeleton_MoveState(this, stateMachine, "move", moveStateData, this);
        idleState = new Skeleton_IdleState(this, stateMachine, "idle", idleStateData, this);
        playerDetectedState = new Skeleton_PlayerDetectedState(this, stateMachine, "playerDetected", playerDetectedStateData, this);
        lookForPlayerState = new Skeleton_LookForPlayerState(this, stateMachine, "lookForPlayer", lookForPlayerStateData, this);
        hurtState = new Skeleton_HurtState(this, stateMachine, "hurt", hurtStateData, this);
        deadState = new Skeleton_DeadState(this, stateMachine, "dead", deadStateData, this);
        dodgeState = new Skeleton_DodgeState(this, stateMachine, "dodge", dodgeStateData, this);
        rangeAttackState = new Skeleton_RangeAttackState(this, stateMachine, "rangedAttack", rangeAttackPosition, rangeAttackData, this);

        stateMachine.Initialize(moveState);
    }

    public override void Damage(AttackDetails attackDetails)
    {
      base.Damage(attackDetails);
      stateMachine.ChangeState(hurtState);

      if(isDead)
      {
        stateMachine.ChangeState(deadState);
      }
      else if (CheckPlayerInMinAgroRange())
      {
          stateMachine.ChangeState(rangeAttackState);
      }
      else if (!CheckPlayerInMinAgroRange())
      {
          lookForPlayerState.setTurnImmediately(true);
          stateMachine.ChangeState(lookForPlayerState);
      }
    }
}
