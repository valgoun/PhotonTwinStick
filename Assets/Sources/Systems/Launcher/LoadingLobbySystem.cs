using System;
using Entitas;
using Photon;
using TwinStick.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TwinStick.Launcher
{
    /// <summary>
    /// System that react to successful connection to load the next scene
    /// Only runs on server
    /// </summary>
    public class LoadingLobbySystem : ReactiveSystem<NetworkEntity>
    {
        private readonly NetworkContext _context;
        private readonly GameSettings _settings;
        public LoadingLobbySystem(Contexts contexts, GameSettings settings) : base(contexts.network)
        {
            _context = contexts.network;
            _settings = settings;
        }

        protected override ICollector<NetworkEntity> GetTrigger(IContext<NetworkEntity> context)
        {
            return context.CreateCollector(NetworkMatcher.ConnectionSucessful.Added());
        }

        protected override bool Filter(NetworkEntity entity)
        {
            return entity == _context.connectionSucessfulEntity;
        }

        protected override void Execute(System.Collections.Generic.List<NetworkEntity> entities)
        {
            PhotonNetwork.LoadLevel(_settings.LobbyScene);
        }
    }
}