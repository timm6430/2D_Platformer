using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newHurtData", menuName = "Data/State Data/Hurt Data")]
public class D_HurtState : ScriptableObject
{
  public float knockbackTime = 0.2f;
  public float knockbackSpeed = 10f;
  public Vector2 knockbackAngle;

}
