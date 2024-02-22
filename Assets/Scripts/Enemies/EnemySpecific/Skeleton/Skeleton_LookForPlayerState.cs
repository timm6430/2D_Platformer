using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_LookForPlayerState : LookForPlayerState
{
    private Skeleton skeleton;
    public Skeleton_LookForPlayerState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, 
    D_LookForPlayerState stateDate, Skeleton skeleton) : base(entity, stateMachine, animBoolName, stateDate)
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
            stateMachine.ChangeState (skeleton.playerDetectedState);
        }
        else if (isAllTurnsDone)
        {
            stateMachine.ChangeState(skeleton.moveState);
        }
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
