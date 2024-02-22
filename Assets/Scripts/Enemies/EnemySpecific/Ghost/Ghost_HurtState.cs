using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost_HurtState : HurtState
{
  private Ghost ghost;
  public Ghost_HurtState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, 
  D_HurtState stateData, Ghost ghost) : base(entity, stateMachine, animBoolName, stateData)
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
    if (performCloseRangeAction)
    {
      stateMachine.ChangeState(ghost.meleeAttackState);
    }
    else if(isPlayerInMinAgroRange)
    {
      stateMachine.ChangeState(ghost.chaseState);
    }
    else
    {
      ghost.lookForPlayerState.setTurnImmediately(true);
      stateMachine.ChangeState(ghost.lookForPlayerState);
    }
  }

  public override void PhysicsUpdate()
  {
    base.PhysicsUpdate();
  }
}
