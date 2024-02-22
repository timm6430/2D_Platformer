using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost_MeleeAttackState : MeleeAttackState
{
  private Ghost ghost;

  public Ghost_MeleeAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName,
   Transform attackPosition, D_MeleeAttack stateData, Ghost ghost) : base(entity, stateMachine, animBoolName, attackPosition, stateData)
  {
    this.ghost = ghost;
  }

  public override void DoChecks()
  {
    base.DoChecks();
  }

  public override void Enter()
  {
    base.Enter();
  }

  public override void Exit()
  {
    base.Exit();
  }

  public override void LogicUpdate()
  {
    base.LogicUpdate();

    if(isAnimationFinished)
    {
      if(isPlayerInMinAgroRange)
      {
        stateMachine.ChangeState(ghost.playerDetectedState);
      }
      else
      {
        stateMachine.ChangeState(ghost.lookForPlayerState);
      }
    }
  }

  public override void PhysicsUpdate()
  {
    base.PhysicsUpdate();
  }

  public override void TriggerAttack()
  {
    base.TriggerAttack();
  }
}
