using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game, Network, Input, UI, Unique]
public class ViewRootGameOjectComponent : IComponent
{
    public GameObject gameObject;
}