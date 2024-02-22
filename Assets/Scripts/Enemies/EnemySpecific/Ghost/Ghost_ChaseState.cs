using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost_ChaseState : ChaseState
{
    private Ghost ghost;
    public Ghost_ChaseState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, 
     D_ChaseState stateData, Ghost ghost) : base(entity, stateMachine, animBoolName, stateData)
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

        else if(!isDetectingLedge || isDetectingWall)
        {
          stateMachine.ChangeState(ghost.lookForPlayerState);
        }
        
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
