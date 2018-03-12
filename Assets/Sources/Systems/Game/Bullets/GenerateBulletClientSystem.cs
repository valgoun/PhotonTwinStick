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
    public class GenerateBulletClientSystem : IInitializeSystem
    {
        private readonly GameContext _gameContext;
        private readonly NetworkContext _networkContext;
        private readonly Component _container;

        public GenerateBulletClientSystem (Contexts contexts, Component container)
        {
            _gameContext = contexts.game;
            _networkContext = contexts.network;
            _container = container;
        }

        public void Initialize ()
        {
            _networkContext.eventStream.stream.Where (e => e.eventCode == (byte) (NetworkActions.SpawnBulletResult))
                .Select (e => (int) e.content)
                .Subscribe (SyncBullet)
                .AddTo (_container);
        }

        private void SyncBullet (int viewID)
        {
            var photonView = PhotonView.Find (viewID);
            var bulletGO = photonView.gameObject;

            bulletGO.transform.SetParent (_gameContext.viewRootGameOject.gameObject.transform);

            var bulletEntity = _gameContext.CreateEntity ();
            bulletEntity.AddGameView (bulletGO, bulletGO.transform);
            bulletEntity.AddPhotonView (photonView);
            bulletEntity.AddPhysicView (bulletGO.GetComponent<Rigidbody> ());

            bulletEntity.physicView.rigidbody.velocity = bulletEntity.gameView.transform.forward * 10.0f;

            if (PhotonNetwork.isMasterClient)
            {
                Observable.Timer (TimeSpan.FromSeconds (2f)).Subscribe (_ => bulletEntity.isMarkForDeletion = true).AddTo (bulletGO);
                bulletGO.OnTriggerEnterAsObservable ().Subscribe (x => bulletEntity.AddBulletTriggerEnter (x)).AddTo (bulletGO);
            }
        }
    }
}