using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost_MoveState : MoveState
{
    private Ghost ghost;
    public Ghost_MoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, 
    D_MoveState stateDate, Ghost ghost) : base(entity, stateMachine, animBoolName, stateDate)
    {
        this.ghost = ghost;
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
            stateMachine.ChangeState(ghost.playerDetectedState);
        }
        
        else if(isDetectingWall || !isDetectingLedge)
        {
            ghost.idleState.setFlipAfterIdle(true);
            stateMachine.ChangeState(ghost.idleState);
        }
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
