using System.Collections;
using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;


/// <summary>
/// Should we try to connect to the game server ?
/// </summary>
[Network, Unique, UniquePrefix ("")]
public class ShouldConnectComponent : IComponent
{

}