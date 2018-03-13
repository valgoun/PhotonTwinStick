using System;
using System.Collections;
using System.Collections.Generic;
using Entitas;
using Photon;
using UnityEngine;

namespace TwinStick.Lobby
{
    /// <summary>
    /// System that select the right spawning point for the local player
    /// </summary>
    public class CreateSpawnPointSystem : IInitializeSystem
    {
        private readonly List<Vector3> _spawnPoints;
        private readonly string _lobbyPlateformPrefabName;
        private readonly GameContext _context;


        public CreateSpawnPointSystem(Contexts contexts, List<Vector3> spawnPoints, string lobbyPlateformPrefabName)
        {
            _spawnPoints = spawnPoints;
            _lobbyPlateformPrefabName = lobbyPlateformPrefabName;
            _context = contexts.game;
        }

        public void Initialize()
        {
            var pt = _spawnPoints[PhotonNetwork.player.ID - 1];
            _context.ReplaceSpawnPoint(pt);
        }
    }
}