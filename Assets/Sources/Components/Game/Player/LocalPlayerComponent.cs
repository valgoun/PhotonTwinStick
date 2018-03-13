using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

/// <summary>
/// Flag component that indicates the local player
/// </summary>
[Game, Unique]
public class LocalPlayerComponent : IComponent { }