using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_HurtState : HurtState
{
private Skeleton skeleton;
  public Skeleton_HurtState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, 
  D_HurtState stateData, Skeleton skeleton) : base(entity, stateMachine, animBoolName, stateData)
  {
    this.skeleton = skeleton;
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

    if(isPlayerInMinAgroRange)
    {
      stateMachine.ChangeState(skeleton.playerDetectedState);
    }
    else
    {
      skeleton.lookForPlayerState.setTurnImmediately(true);
      stateMachine.ChangeState(skeleton.lookForPlayerState);
    }
  }

  public override void PhysicsUpdate()
  {
    base.PhysicsUpdate();
  }
}
