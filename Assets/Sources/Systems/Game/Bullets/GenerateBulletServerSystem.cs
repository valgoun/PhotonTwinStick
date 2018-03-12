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

            // bulletGO.transform.SetParent (_gameContext.viewRootGameOject.gameObject.transform);

            // var bulletEntity = _gameContext.CreateEntity ();
            // bulletEntity.AddGameView (bulletGO, bulletGO.transform);
            // bulletEntity.AddPhysicView (bulletGO.GetComponent<Rigidbody> ());
            // bulletEntity.AddPhotonView (bulletGO.GetComponent<PhotonView> ());

            // bulletEntity.physicView.rigidbody.velocity = bulletEntity.gameView.transform.forward * 10.0f;

            // Observable.Timer (TimeSpan.FromSeconds (2f)).Subscribe (_ => bulletEntity.isMarkForDeletion = true).AddTo (bulletGO);
            // bulletGO.OnTriggerEnterAsObservable ().Subscribe (x => bulletEntity.AddBulletTriggerEnter (x)).AddTo (bulletGO);

            PhotonNetwork.RaiseEvent ((byte) (NetworkActions.SpawnBulletResult),
                bulletGO.GetComponent<PhotonView> ().viewID,
                true,
                new RaiseEventOptions () { Receivers = ReceiverGroup.All });
        }
    }
}