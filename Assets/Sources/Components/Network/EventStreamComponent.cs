using System;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UniRx;

/// <summary>
/// Store the event stream coming from Photon
/// </summary>
[Network, Unique]
public class EventStreamComponent : IComponent
{
    public IObservable<NetworkEventArgs> stream;
}

/// <summary>
/// Represent the event stream arguments
/// </summary>
public class NetworkEventArgs
{
    public byte eventCode;
    public object content;
    public int senderId;
}