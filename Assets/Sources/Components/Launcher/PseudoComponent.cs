using System.Collections;
using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;


/// <summary>
/// Store the Pseudo of the active player
/// </summary>
[Game, Unique]
public class PseudoComponent : IComponent
{
	public string Pseudo;
}