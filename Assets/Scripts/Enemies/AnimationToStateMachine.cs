using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationToStateMachine : MonoBehaviour
{
  public AttackState attackState;
  private void TiggerAttack()
  {
    attackState.TriggerAttack();
  }
  private void FinishAttack()
  {
    attackState.FinishAttack();
  }
}
