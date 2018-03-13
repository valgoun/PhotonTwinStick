using Entitas;
using UnityEngine;

namespace TwinStick.Game
{
    /// <summary>
    /// This system rotate the player according to the mouse position and its plane
    /// </summary>
    public class RotatePlayerSystem : IExecuteSystem
    {
        private readonly GameContext _gameContext;
        private readonly InputContext _inputContext;

        public RotatePlayerSystem (Contexts contexts)
        {
            _gameContext = contexts.game;
            _inputContext = contexts.input;
        }
        public void Execute ()
        {
            if (_gameContext.isLocalPlayer && _inputContext.hasMousePosition)
            {
                var localPlayer = _gameContext.localPlayerEntity;
                var mousePosition = _inputContext.mousePosition.ScreenPosition;
                var ray = Camera.main.ScreenPointToRay (mousePosition);
                var playerTransform = localPlayer.gameView.transform;

                float d;
                localPlayer.playerPlane.value.Raycast (ray, out d);
                Vector3 intersectionPoint = ray.origin + ray.direction * d;

                playerTransform.LookAt (intersectionPoint);
            }
        }
    }
}