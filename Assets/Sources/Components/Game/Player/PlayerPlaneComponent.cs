using Entitas;
using UnityEngine;


/// <summary>
/// The 3D plane of the player
/// </summary>
[Game]
public class PlayerPlaneComponent : IComponent
{
    public Plane value;
}