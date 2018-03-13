using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;


/// <summary>
/// Store the View root GameObject
/// </summary>
[Game, Network, Input, UI, Unique]
public class ViewRootGameOjectComponent : IComponent
{
    public GameObject gameObject;
}