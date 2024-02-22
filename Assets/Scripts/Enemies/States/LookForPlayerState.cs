﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookForPlayerState : State
{
    protected D_LookForPlayerState stateData;
    protected bool turnImmediately;
    protected bool isPlayerInMinAgroRange;
    protected bool isAllTurnsDone;
    protected bool isAllTurnsTimeDone;
    protected float lastTimeTurn;
    protected int amountOfTurnsDone;
    public LookForPlayerState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, 
    D_LookForPlayerState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
    }
    public override void Enter()
    {
        base.Enter();  
        isAllTurnsDone = false;
        isAllTurnsTimeDone = false;
        lastTimeTurn = startTime;
        amountOfTurnsDone = 0;
        entity.SetMovingVelocity(0f);
    }
    public override void Exit()
    {
        base.Exit();
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(turnImmediately)
        {
            entity.Flip();
            lastTimeTurn = Time.time;
            amountOfTurnsDone++;
            turnImmediately = false;
        }
        else if (Time.time >= lastTimeTurn + stateData.timeBetweenTurns && !isAllTurnsDone)
        {
            entity.Flip();
            lastTimeTurn = Time.time;
            amountOfTurnsDone++;
        }

        if (amountOfTurnsDone >= stateData.amountOfTurns)
        {
            isAllTurnsDone = true;
        }

        if(Time.time >=  lastTimeTurn + stateData.timeBetweenTurns && !isAllTurnsDone)
        {
            isAllTurnsTimeDone = true;
        }
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public void setTurnImmediately(bool flip)
    {
        turnImmediately = flip;
    }
}