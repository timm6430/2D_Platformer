using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    protected D_MoveState stateData;
    protected bool isDetectingWall;
    protected bool isDetectingLedge;
    protected bool isPlayerInMinAgroRange;

    public MoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, 
    D_MoveState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isDetectingLedge = entity.checkLedge();
        isDetectingWall = entity.checkWall();
        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
    }

    //when this enter is called the enter in state is also called
    public override void Enter()
    {
        //State Enter function being called
        base.Enter();
        entity.SetMovingVelocity(stateData.movementSpeed);
        DoChecks();
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
