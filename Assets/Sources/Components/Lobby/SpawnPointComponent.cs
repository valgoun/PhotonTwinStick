using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

/// <summary>
/// Component that holds where the player should spawn
/// </summary>
[Game, Unique]
public class SpawnPointComponent : IComponent
{
    public Vector3 position;
}