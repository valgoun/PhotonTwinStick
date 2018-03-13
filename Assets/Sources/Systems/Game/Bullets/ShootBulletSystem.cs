using System;
using System.Collections;
using System.Collections.Generic;
using Entitas;
using TwinStick.Utils;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace TwinStick.Game
{
    /// <summary>
    /// It reacts to player inputs to send a message to the server to spawn a bullet
    /// Its goals is to verify that we can shoot and then to send the position and rotation of the bullet to spawn
    /// </summary>
    public class ShootBulletSystem : ReactiveSystem<InputEntity>
    {
        private readonly GameContext _gameContext;
        private readonly InputContext _inputContext;
        private bool _canShoot = true;

        public ShootBulletSystem (Contexts contexts) : base (contexts.input)
        {
            _gameContext = contexts.game;
            _inputContext = contexts.input;
        }

        protected override ICollector<InputEntity> GetTrigger (IContext<InputEntity> context)
        {
            return context.CreateCollector (InputMatcher.AnyOf (InputMatcher.MouseClickDown, InputMatcher.MouseClickStay));
        }

        protected override bool Filter (InputEntity entity)
        {
            return (entity == _inputContext.mouseClickDownEntity) || (entity == _inputContext.mouseClickStayEntity);
        }

        protected override void Execute (List<InputEntity> entities)
        {
            // can we shoot and is local player set ?
            if (_canShoot && _gameContext.isLocalPlayer)
            {
                var localPlayer = _gameContext.localPlayerEntity;
                var position = localPlayer.shootSpawn.transform.position;
                var rotation = localPlayer.shootSpawn.transform.rotation;

                PhotonNetwork.RaiseEvent (
                    (byte) (NetworkActions.SpawnBullet),
                    new object[] { position, rotation },
                    true,
                    new RaiseEventOptions () { Receivers = ReceiverGroup.All });

                _canShoot = false;
                Observable.Timer (TimeSpan.FromSeconds (0.2f)).Subscribe (_ => _canShoot = true).AddTo (localPlayer.gameView.gameObject);
            }
        }
    }
}