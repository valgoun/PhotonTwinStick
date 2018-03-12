using System;
using Entitas;
using Photon;
using UniRx;
using UnityEngine;

namespace TwinStick.Network
{
    public class EventStreamInitializerSystem : IInitializeSystem
    {
        private readonly NetworkContext _context;

        public EventStreamInitializerSystem (Contexts contexts)
        {
            _context = contexts.network;
        }
        public void Initialize ()
        {
            var stream = Observable.FromEvent<PhotonNetwork.EventCallback, NetworkEventArgs> (
                    h => (e, c, s) => h (new NetworkEventArgs () { eventCode = e, content = c, senderId = s }),
                    h => PhotonNetwork.OnEventCall += h,
                    h => PhotonNetwork.OnEventCall -= h
                );
            _context.SetEventStream (stream);
        }
    }
}