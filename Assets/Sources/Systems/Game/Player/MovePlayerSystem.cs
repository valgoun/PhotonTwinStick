using Entitas;
using UnityEngine;

namespace TwinStick.Game
{
    /// <summary>
    /// This system move the player according to the move inputs
    /// because we're using a rigidbody, this system has to run on FixedUpdate
    /// </summary>
    public class MovePlayerSystem : IExecuteSystem
    {
        private readonly GameContext _gameContext;
        private readonly InputContext _inputContext;
        public MovePlayerSystem (Contexts contexts)
        {
            _gameContext = contexts.game;
            _inputContext = contexts.input;
        }
        public void Execute ()
        {
            if (_inputContext.hasMousePosition && _gameContext.isLocalPlayer)
            {
                var localPlayer = _gameContext.localPlayerEntity;
                var axesValue = _inputContext.moveInput.AxesValue;
                Vector3 moveVector = new Vector3 (
                    axesValue.x,
                    0,
                    axesValue.y
                );

                moveVector = Vector3.ClampMagnitude (moveVector, 1f);
                moveVector *= Time.fixedDeltaTime;
                moveVector *= localPlayer.maxSpeed.value;

                localPlayer.physicView.rigidbody.MovePosition (localPlayer.physicView.rigidbody.position + moveVector);
            }

        }

    }
}