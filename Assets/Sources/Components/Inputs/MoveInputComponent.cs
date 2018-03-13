using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

/// <summary>
/// Store the move input as a 2D vector
/// </summary>
[Input, Unique]
public class MoveInputComponent : IComponent
{
    public Vector2 AxesValue;
}