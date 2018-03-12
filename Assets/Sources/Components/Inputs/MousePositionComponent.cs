using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Input, Unique]
public class MousePositionComponent : IComponent
{
    public Vector3 ScreenPosition;
}