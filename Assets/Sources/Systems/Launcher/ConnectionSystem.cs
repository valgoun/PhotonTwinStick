using System;
using System.Collections;
using System.Collections.Generic;
using Entitas;
using Photon;
using TwinStick.Utils;
using UnityEngine;

namespace TwinStick.Launcher
{
    /// <summary>
    /// System that manage initial connection, and room creation
    /// </summary>
    public class ConnectionSystem : ReactiveSystem<NetworkEntity>, ICleanupSystem
    {
        private readonly NetworkContext _networkContext;
        private readonly GameContext _gameContext;
        private readonly LauncherSystems _callBackCaller;
        private readonly GameSettings _settings;

        public ConnectionSystem (Contexts contexts, LauncherSystems callBackCaller, GameSettings settings) : base (contexts.network)
        {
            _networkContext = contexts.network;
            _gameContext = contexts.game;
            _settings = settings;
            _callBackCaller = callBackCaller;

            _callBackCaller.onConnectedToMaster += OnConnectedToMaster;
            _callBackCaller.onPhotonRandomJoinFailed += OnPhotonRandomJoinFailed;
            _callBackCaller.onJoinedRoom += OnJoinedRoom;

        }

        protected override ICollector<NetworkEntity> GetTrigger (IContext<NetworkEntity> context)
        {
            return context.CreateCollector (NetworkMatcher.ShouldConnect);
        }

        protected override bool Filter (NetworkEntity entity)
        {
            return entity == _networkContext.shouldConnectEntity;
        }

        protected override void Execute (List<NetworkEntity> entities)
        {
            if (_gameContext.hasPseudo)
            {
                if (PhotonNetwork.connected)
                {
                    PhotonNetwork.JoinRandomRoom ();
                }
                else
                {
                    PhotonNetwork.ConnectUsingSettings (_settings.GameVersion);
                }
                _networkContext.PendingConnection = true;
            }
            else
            {
                Debug.LogError ("No Pseudo Entered ! Can't connect");
            }
        }

        private void OnConnectedToMaster ()
        {
            PhotonNetwork.JoinRandomRoom ();
        }

        private void OnPhotonRandomJoinFailed (object[] codeAndMsg)
        {
            PhotonNetwork.CreateRoom (null, new RoomOptions () { MaxPlayers = _settings.MaxPlayerPerRoom }, null);
        }

        private void OnJoinedRoom ()
        {
            Debug.Log ("Room Joined : " + PhotonNetwork.room);
            _networkContext.PendingConnection = false;
            _networkContext.ConnectionSucessful = true;
        }

        public void Cleanup ()
        {
            _networkContext.ConnectionSucessful = false;
        }
    }
}