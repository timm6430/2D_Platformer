using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "newRangeAttackStateData", menuName = "Data/State Data/Range Attack State")]
public class D_RangeAttackState : ScriptableObject
{
    public GameObject projectile;
    public float projectileDamage = 1f;
    public float projectileSpeed = 5f;
    public float projectileTravelDistance = 4f;
}
