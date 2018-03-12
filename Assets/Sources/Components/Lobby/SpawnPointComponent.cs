using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game, Unique]
public class SpawnPointComponent : IComponent
{
    public Vector3 position;
}