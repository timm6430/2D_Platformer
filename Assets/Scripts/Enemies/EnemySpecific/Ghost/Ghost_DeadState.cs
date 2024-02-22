﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost_DeadState : DeadState
{
  private Ghost ghost;
  public Ghost_DeadState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, 
  D_DeadState stateData, Ghost ghost) : base(entity, stateMachine, animBoolName, stateData)
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
  }

  public override void PhysicsUpdate()
  {
    base.PhysicsUpdate();
  }
}
