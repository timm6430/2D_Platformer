using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost_IdleState : IdleState
{
    private Ghost ghost;
    public Ghost_IdleState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, 
     D_IdleState stateData, Ghost ghost) : base(entity, stateMachine, animBoolName, stateData)
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
        
        if(isIdleTimeOver)
        {
            stateMachine.ChangeState(ghost.moveState);
        }
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
    
}
