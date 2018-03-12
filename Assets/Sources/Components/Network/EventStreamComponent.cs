using System;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UniRx;

[Network, Unique]
public class EventStreamComponent : IComponent
{
    public IObservable<NetworkEventArgs> stream;
}

public class NetworkEventArgs
{
    public byte eventCode;
    public object content;
    public int senderId;
}