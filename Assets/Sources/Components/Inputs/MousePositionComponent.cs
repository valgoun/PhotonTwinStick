using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;


/// <summary>
/// Store the Mouse position on the screen
/// z component of the Vector3 is always 0
/// </summary>
[Input, Unique]
public class MousePositionComponent : IComponent
{
    public Vector3 ScreenPosition;
}