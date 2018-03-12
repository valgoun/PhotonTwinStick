using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game]
public class GameViewComponent : IComponent
{
    public GameObject gameObject;
    public Transform transform;
}