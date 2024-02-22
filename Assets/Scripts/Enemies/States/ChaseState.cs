using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    protected D_ChaseState stateData;
    protected bool isDetectingLedge;
    protected bool isDetectingWall;
    protected bool performCloseRangeAction;

    public ChaseState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, 
    D_ChaseState stateData) : base(entity, stateMachine, animBoolName)
    {
      this.stateData = stateData;
    }

    public override void DoChecks()
    {
      base.DoChecks();
      isDetectingLedge = entity.checkLedge();
      isDetectingWall = entity.checkWall();

      performCloseRangeAction = entity.CheckPlayerInCloseRangeAction();
    }
    public override void Enter()
    {
      base.Enter();
      entity.SetMovingVelocity(stateData.chaseSpeed);
        
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
