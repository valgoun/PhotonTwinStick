using Entitas;
using UnityEngine;

/// <summary>
/// Component that indicates that the bullet has entered a trigger
/// other : the collider entered
/// </summary>
[Game]
public class BulletTriggerEnterComponent : IComponent
{
    public Collider other;
}