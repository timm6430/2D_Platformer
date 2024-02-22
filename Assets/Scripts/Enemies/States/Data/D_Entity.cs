using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEntityData", menuName = "Data/Entity Data/Base Data")]
public class D_Entity : ScriptableObject
{
  public float maxHealth = 5f;

  public float wallCheckDistacne = 0.2f;
  public float ledgeCheckDistance = 0.4f;
  public float groundCheckRadius = 0.3f;

  public float minAgroDistance = 2f;
  public float maxAgroDistance = 3f;
  public float closeRangeActionDistance = 1f;

/*
  public float lastTouchDamageTime
  public float touchDamageCooldown = 0.5f;
  public float touchDamage = 1f;
  public float touchDamageWidth = 1f;
  public float touchDamageHeight = 1f;
  }*/
    
  public LayerMask whatIsPlayer;
  public LayerMask whatIsGround;

}
