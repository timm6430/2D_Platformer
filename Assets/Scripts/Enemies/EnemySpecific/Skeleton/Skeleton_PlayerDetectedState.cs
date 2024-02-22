using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_PlayerDetectedState : PlayerDetectedState
{
    private Skeleton skeleton;
    public Skeleton_PlayerDetectedState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, 
    D_PlayerDetected stateDate, Skeleton skeleton) : base(entity, stateMachine, animBoolName, stateDate)
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
        if (Time.time >= skeleton.dodgeState.startTime + skeleton.dodgeStateData.dodgeCooldown)
        {
            stateMachine.ChangeState(skeleton.dodgeState);
        }
        else if (performLongRangeAction)
        {
            stateMachine.ChangeState(skeleton.rangeAttackState);
        }
        else if (!isPlayerInMaxAgroRange)
        {
            stateMachine.ChangeState(skeleton.lookForPlayerState);
        }
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
