using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Entitas;
using Photon;
using TwinStick.Game;
using TwinStick.Inputs;
using TwinStick.Network;
using TwinStick.Utils;
using UnityEngine;

namespace TwinStick.Lobby
{
    public class LobbySystems : Photon.PunBehaviour
    {
        //-------------------------------------------------
        //	PUBLIC VARIABLES
        //-------------------------------------------------
        public InputSettings InputSettings;
        public List<Transform> SpawningPoints;
        public Transform CameraPivot;
        public GameObject LobbyPlateformPrefab;
        public GameObject PlayerViewPrefab;

        //-------------------------------------------------
        //	PUBLIC VARIABLES
        //-------------------------------------------------
        private Systems _systems;
        private Systems _physicSystems;
        private Systems _serverSystems;
        private Contexts _contexts;
        private bool _serverSystemInitialized = false;

        //-------------------------------------------------
        //	UNITY FUNCTIONS
        //-------------------------------------------------
        void Awake()
        {
            _contexts = Contexts.sharedInstance;

            _systems = new Feature("Lobby Systems");
            _physicSystems = new Feature("Physics Systems");
            _serverSystems = new Feature("Server Systems");

            _systems.Add(new EventStreamInitializerSystem(_contexts));
            _systems.Add(new InputsSytem(_contexts, InputSettings));
            _systems.Add(new CreateViewRootGameObjectSystem(_contexts, GameObject.Find("[VIEWS]")));
            _systems.Add(new CreateSpawnPointSystem(_contexts, SpawningPoints.Select(x => x.position).ToList(), LobbyPlateformPrefab.name));
            _systems.Add(new CreateLocalPlayerSystem(_contexts, PlayerViewPrefab.name));
            _systems.Add(new UpdatePlayerPlaneSystem(_contexts));
            _systems.Add(new RotatePlayerSystem(_contexts));
            _systems.Add(new ShootBulletSystem(_contexts));
            _systems.Add(new GenerateBulletClientSystem(_contexts, this));
            _systems.Add(new DestroySystem(_contexts));

            _physicSystems.Add(new MovePlayerSystem(_contexts));
            _physicSystems.Add(new CameraFollowPlayerSystem(_contexts, CameraPivot));

            _serverSystems.Add(new GenerateBulletServerSystem(_contexts, this));
            _serverSystems.Add(new BulletTriggerSystem(_contexts));
        }

        void Start()
        {
            _contexts.network.PendingConnection = false;
            _systems.Initialize();
            _physicSystems.Initialize();
            if (PhotonNetwork.isMasterClient)
            {
                _serverSystems.Initialize();
                _serverSystemInitialized = true;            }
        }

        void Update()
        {

            _systems.Execute();
            _systems.Cleanup();

            if (PhotonNetwork.isMasterClient)
            {
                _serverSystems.Execute();
                _serverSystems.Cleanup();
            }
        }

        void FixedUpdate()
        {
            _physicSystems.Execute();
        }

        public override void OnMasterClientSwitched(PhotonPlayer newMasterClient)
        {
            if(newMasterClient.ID == PhotonNetwork.player.ID && !_serverSystemInitialized)
            {
                _serverSystemInitialized = true;
                _serverSystems.Initialize();
            }
        }
    }
}