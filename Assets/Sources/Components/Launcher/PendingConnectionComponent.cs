using Entitas;
using Entitas.CodeGeneration.Attributes;

/// <summary>
/// Are we trying to connect to the game server ?
/// </summary>
[Network, Unique, UniquePrefix ("")]
public class PendingConnectionComponent : IComponent { }