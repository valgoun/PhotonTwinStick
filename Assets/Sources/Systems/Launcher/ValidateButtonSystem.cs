using System;
using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;
using UnityEngine.UI;

namespace TwinStick.Launcher
{
    /// <summary>
    /// System that connect the connection button to the ECS
    /// </summary>
    public class ValidateButtonSystem : IInitializeSystem, ICleanupSystem
    {
        private readonly Button _button;
        private readonly NetworkContext _networkContext;

        public ValidateButtonSystem (Contexts contexts, Button associatedButton)
        {
            _button = associatedButton;
            _networkContext = contexts.network;
        }

        public void Cleanup ()
        {
            _networkContext.ShouldConnect = false;
        }

        public void Initialize ()
        {
            _button.onClick.AddListener (OnValidate);
        }

        private void OnValidate ()
        {
            _networkContext.ShouldConnect = true;
        }
    }
}