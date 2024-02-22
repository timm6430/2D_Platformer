using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtState : State
{
  protected D_HurtState stateData;
  protected bool isGrounded;
  protected bool isMovementStopped;
  protected bool performCloseRangeAction;
  protected bool isPlayerInMinAgroRange;

  public HurtState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, 
  D_HurtState stateData) : base(entity, stateMachine, animBoolName)
  {
    this.stateData = stateData;
  }

  public override void DoChecks()
  {
    base.DoChecks();
    isGrounded = entity.CheckGround();
  }
  public override void Enter()
  {
    base.Enter();
    isMovementStopped = false;
    performCloseRangeAction = entity.CheckPlayerInCloseRangeAction();
    isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
    entity.SetActionVelocity(stateData.knockbackSpeed, stateData.knockbackAngle, entity.lastDamageDirection);
        
  }
  public override void Exit()
  {
    base.Exit();
  }
  public override void LogicUpdate()
  {
    base.LogicUpdate();
    if(isGrounded && Time.time >= startTime + stateData.knockbackTime && !isMovementStopped)
    {
      isMovementStopped = true;
      entity.SetMovingVelocity(0f);
    }
  }
  public override void PhysicsUpdate()
  {
    base.PhysicsUpdate();
  }
}
