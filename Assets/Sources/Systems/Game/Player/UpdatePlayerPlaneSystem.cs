using Entitas;
using UnityEngine;

namespace TwinStick.Game
{
    /// <summary>
    /// This system updates the 3D plane on which the player moves
    /// </summary>
    public class UpdatePlayerPlaneSystem : IExecuteSystem
    {
        private readonly GameContext _gameContext;

        public UpdatePlayerPlaneSystem (Contexts contexts)
        {
            _gameContext = contexts.game;
        }

        public void Execute ()
        {
            if (_gameContext.isLocalPlayer)
            {
                var playerView = _gameContext.localPlayerEntity.gameView.transform;
                _gameContext.localPlayerEntity.ReplacePlayerPlane (new Plane (Vector3.up, playerView.position));
            }
        }
    }
}