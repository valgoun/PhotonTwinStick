using Entitas;
using Entitas.CodeGeneration.Attributes;


/// <summary>
/// How smooth the camera moves
/// </summary>
[Game, Unique]
public class CameraSmoothTimeComponent : IComponent
{
    public float value;
}