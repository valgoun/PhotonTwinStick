using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Entitas;
using UnityEngine;
using UnityEngine.UI;

namespace TwinStick.Launcher
{
    public class ConnectionUiSystem : ReactiveSystem<NetworkEntity>
    {
        private readonly NetworkContext _context;
        private readonly CanvasGroup _loadingScreen;

        public ConnectionUiSystem (Contexts contexts, CanvasGroup loadingScreen) : base (contexts.network)
        {
            _context = contexts.network;
            _loadingScreen = loadingScreen;
        }
        protected override ICollector<NetworkEntity> GetTrigger (IContext<NetworkEntity> context)
        {
            return context.CreateCollector (NetworkMatcher.PendingConnection.AddedOrRemoved ());
        }

        protected override bool Filter (NetworkEntity entity)
        {
            return true;
        }

        protected override void Execute (List<NetworkEntity> entities)
        {
            if (_context.PendingConnection)
            {
                _loadingScreen.gameObject.SetActive (true);
                _loadingScreen.DOFade (1, 0.3f).SetEase (Ease.OutExpo);
            }
            else
            {
                _loadingScreen.DOFade (0, 0.3f).SetEase (Ease.OutExpo).OnComplete (() => _loadingScreen.gameObject.SetActive (false));
            }
        }
    }
}