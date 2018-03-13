using System;
using System.Collections;
using System.Collections.Generic;
using Entitas;
using Photon;
using TwinStick.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TwinStick.Launcher
{
    public class LauncherSystems : Photon.PunBehaviour
    {

        //-------------------------------------------------
        //	PUBLIC VARIABLES
        //-------------------------------------------------
        public InputField PseudoField;
        public Button ValidateButton;
        public GameSettings Settings;
        public CanvasGroup LoadingScreen;
        //-------------------------------------------------
        //	PUBLIC EVENTS
        //-------------------------------------------------
        public event Action onConnectedToMaster;
        public event Action<object[]> onPhotonRandomJoinFailed;
        public event Action onJoinedRoom;

        //-------------------------------------------------
        //	PRIVATE VARIABLES
        //-------------------------------------------------
        private Entitas.Systems _systems;
        private Entitas.Systems _serverSystems;
        private Contexts _contexts;
        private bool _serverSystemsInitialized = false;

        //-------------------------------------------------
        //	UNITY FUNCTIONS
        //-------------------------------------------------
        void Awake()
        {
            PhotonNetwork.autoJoinLobby = false;
            PhotonNetwork.automaticallySyncScene = true;

            _contexts = Contexts.sharedInstance;
            _systems = new Feature("Launcher Systems");
            _serverSystems = new Feature("Server Systems");

            _systems.Add(new ModifyPseudoSystem(_contexts, PseudoField));
            _systems.Add(new ValidateButtonSystem(_contexts, ValidateButton));
            _systems.Add(new ConnectionSystem(_contexts, this, Settings));
            _systems.Add(new ConnectionUiSystem(_contexts, LoadingScreen));

            _serverSystems.Add(new LoadingLobbySystem(_contexts, Settings));
        }

        void Start()
        {
            _systems.Initialize();
        }

        void Update()
        {
            if (PhotonNetwork.isMasterClient)
            {
                if (!_serverSystemsInitialized)
                {
                    _serverSystemsInitialized = true;
                    _serverSystems.Initialize();
                }
                _serverSystems.Execute();
                _serverSystems.Cleanup();
            }


            _systems.Execute();
            _systems.Cleanup();
        }

        //-------------------------------------------------
        // PHOTON CALLBACKS
        //-------------------------------------------------
        public override void OnConnectedToMaster() => onConnectedToMaster?.Invoke();
        public override void OnPhotonRandomJoinFailed(object[] codeAndMsg) => onPhotonRandomJoinFailed?.Invoke(codeAndMsg);
        public override void OnJoinedRoom() => onJoinedRoom?.Invoke();
    }

}