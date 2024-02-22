﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthReaction : MonoBehaviour
{
    public FloatValue playerHealth;
    public SignalSender healthSignal;

    public void Use (int amountToIncrease)
    {
        playerHealth.runtimeValue += amountToIncrease;
        healthSignal.Raise();
    }
}
