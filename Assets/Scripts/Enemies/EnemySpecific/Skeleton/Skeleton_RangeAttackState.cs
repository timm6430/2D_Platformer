using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_RangeAttackState : RangeAttackState
{
    private Skeleton skeleton;
    public Skeleton_RangeAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, 
    D_RangeAttackState stateData, Skeleton skeleton) : base(entity, stateMachine, animBoolName, attackPosition, stateData)
    {
        this.skeleton = skeleton;
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

        if (isAnimationFinished)
        {
            if (isPlayerInMinAgroRange)
            {
                stateMachine.ChangeState(skeleton.playerDetectedState);
            }
            else
            {
                stateMachine.ChangeState(skeleton.lookForPlayerState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
    }
}
