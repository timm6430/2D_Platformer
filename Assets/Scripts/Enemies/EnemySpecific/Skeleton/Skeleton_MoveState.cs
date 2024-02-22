using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_MoveState : MoveState
{
    private Skeleton skeleton;
    public Skeleton_MoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, 
    D_MoveState stateDate, Skeleton skeleton) : base(entity, stateMachine, animBoolName, stateDate)
    {
        this.skeleton = skeleton;
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

        if (isPlayerInMinAgroRange)
        {
            stateMachine.ChangeState(skeleton.playerDetectedState);
        }

        else if (isDetectingWall || !isDetectingLedge)
        {
            skeleton.idleState.setFlipAfterIdle(true);
            stateMachine.ChangeState(skeleton.idleState);
        }
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
