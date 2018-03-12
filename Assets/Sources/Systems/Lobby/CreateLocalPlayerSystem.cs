using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Entitas;
using Entitas;
using Photon;
using UnityEngine;

namespace TwinStick.Lobby
{
    public class CreateLocalPlayerSystem : IInitializeSystem
    {
        private readonly GameContext _context;
        private readonly string _prefabName;

        public CreateLocalPlayerSystem (Contexts contexts, string PrefabName)
        {
            _context = contexts.game;
            _prefabName = PrefabName;
        }
        public void Initialize ()
        {
            _context.isLocalPlayer = true;

            var playerView = PhotonNetwork.Instantiate (_prefabName, _context.spawnPoint.position, Quaternion.identity, 0);

            playerView.transform.SetParent (_context.viewRootGameOject.gameObject.transform);

            Transform shootSpawnTransform = null;
            foreach (Transform child in playerView.transform)
            {
                if (child.CompareTag ("SpawnPoint"))
                {
                    shootSpawnTransform = child;
                    break;
                }
            }

            var localPlayer = _context.localPlayerEntity;

            localPlayer.AddGameView (playerView, playerView.transform);
            localPlayer.AddPhysicView (playerView.GetComponent<Rigidbody> ());
            localPlayer.AddMaxSpeed (4.5f);
            localPlayer.AddShootSpawn (shootSpawnTransform);
            localPlayer.AddPhotonView (playerView.GetComponent<PhotonView> ());
        }
    }
}