using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost_PlayerDetectedState : PlayerDetectedState
{
    private Ghost ghost;
    public Ghost_PlayerDetectedState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, 
    D_PlayerDetected stateDate, Ghost ghost) : base(entity, stateMachine, animBoolName, stateDate)
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
        if(performCloseRangeAction)
        {
          stateMachine.ChangeState(ghost.meleeAttackState);
        }
        if(performLongRangeAction)
        {
            stateMachine.ChangeState(ghost.chaseState);
        }
        else if (!isPlayerInMaxAgroRange)
        {
            stateMachine.ChangeState(ghost.lookForPlayerState);
        }
        else if (!isDetectingLedge)
        {
          entity.Flip();
          stateMachine.ChangeState(ghost.moveState);
        }
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
