using System;
using Entitas;
using Photon;
using TwinStick.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TwinStick.Launcher
{
    public class LoadingLobbySystem : ReactiveSystem<NetworkEntity>
    {
        private readonly NetworkContext _context;
        private readonly GameSettings _settings;
        public LoadingLobbySystem (Contexts contexts, GameSettings settings) : base (contexts.network)
        {
            _context = contexts.network;
            _settings = settings;
        }

        protected override ICollector<NetworkEntity> GetTrigger (IContext<NetworkEntity> context)
        {
            return context.CreateCollector (NetworkMatcher.ConnectionSucessful.Added ());
        }

        protected override bool Filter (NetworkEntity entity)
        {
            return entity == _context.connectionSucessfulEntity;
        }

        protected override void Execute (System.Collections.Generic.List<NetworkEntity> entities)
        {
            Debug.Log ("MasterClient Status : " + PhotonNetwork.isMasterClient + " ID : " + PhotonNetwork.player.ID);
            if (PhotonNetwork.isMasterClient && PhotonNetwork.player.ID == 1)
            {
                PhotonNetwork.LoadLevel (_settings.LobbyScene);
            }
            // SceneManager.LoadScene (_settings.LobbyScene);
        }
    }
}