using System;
using System.Collections;
using System.Collections.Generic;
using Entitas;
using Photon;
using UnityEngine;

namespace TwinStick.Lobby
{
    public class CreateLobbyPlateformSystem : IInitializeSystem
    {
        private readonly List<Vector3> _spawnPoints;
        private readonly string _lobbyPlateformPrefabName;
        private readonly GameContext _context;

        public CreateLobbyPlateformSystem (Contexts contexts, List<Vector3> spawnPoints, string lobbyPlateformPrefabName)
        {
            _spawnPoints = spawnPoints;
            _lobbyPlateformPrefabName = lobbyPlateformPrefabName;
            _context = contexts.game;
        }

        public void Initialize ()
        {
            var pt = _spawnPoints[PhotonNetwork.player.ID - 1];

            Transform lobbyPlateform = PhotonNetwork.Instantiate (_lobbyPlateformPrefabName, pt, Quaternion.identity, 0).transform;

            lobbyPlateform.SetParent (_context.viewRootGameOject.gameObject.transform);

            foreach (Transform child in lobbyPlateform)
            {
                if (child.CompareTag ("SpawnPoint"))
                {
                    _context.ReplaceSpawnPoint (child.position);
                    return;
                }
            }
        }
    }
}