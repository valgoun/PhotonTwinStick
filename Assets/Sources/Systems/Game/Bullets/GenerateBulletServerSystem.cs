using System;
using System.Collections;
using System.Collections.Generic;
using Entitas;
using Photon;
using TwinStick.Utils;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace TwinStick.Game
{
    /// <summary>
    /// Only run on the server
    /// It goals is to react to a spawn bullet message from a client
    /// and instantiating a scene object using photon
    /// then we send to everyone a response so they can initialize their entity
    /// </summary>
    public class GenerateBulletServerSystem : IInitializeSystem
    {
        private readonly GameContext _gameContext;
        private readonly NetworkContext _networkContext;
        private readonly Component _container;

        public GenerateBulletServerSystem (Contexts contexts, Component container)
        {
            _gameContext = contexts.game;
            _networkContext = contexts.network;
            _container = container;
        }
        public void Initialize ()
        {
            _networkContext.eventStream.stream.Where (e => e.eventCode == (byte) (NetworkActions.SpawnBullet))
                .Select (e =>
                {
                    var data = e.content as object[];
                    var pos = (Vector3) data[0];
                    var rot = (Quaternion) data[1];
                    return new { position = pos, rotation = rot };
                })
                .Subscribe (x => SpawnBullet (x.position, x.rotation))
                .AddTo (_container);
        }

        private void SpawnBullet (Vector3 position, Quaternion rotation)
        {
            var bulletGO = PhotonNetwork.InstantiateSceneObject ("Bullet", position, rotation, 0, new object[] { 10.0f });


            PhotonNetwork.RaiseEvent ((byte) (NetworkActions.SpawnBulletResult),
                bulletGO.GetComponent<PhotonView> ().viewID,
                true,
                new RaiseEventOptions () { Receivers = ReceiverGroup.All });
        }
    }
}