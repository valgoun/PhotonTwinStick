using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;


/// <summary>
/// Store the gameOject and the Transform associated with the entity
/// </summary>
[Game]
public class GameViewComponent : IComponent
{
    public GameObject gameObject;
    public Transform transform;
}