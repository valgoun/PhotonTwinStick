using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Input, Unique]
public class MoveInputComponent : IComponent
{
    public Vector2 AxesValue;
}