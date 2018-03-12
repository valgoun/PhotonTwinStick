using Entitas;
using UnityEngine;

namespace TwinStick.Game
{
    public class CameraFollowPlayerSystem : IExecuteSystem, IInitializeSystem
    {
        private readonly Transform _camera;
        private readonly GameContext _context;

        private Vector3 _velocity = Vector3.zero;
        private Transform _target;

        public CameraFollowPlayerSystem (Contexts contexts, Transform camera)
        {
            _context = contexts.game;
            _camera = camera;
        }
        public void Initialize ()
        {
            _target = _context.localPlayerEntity.gameView.transform;
            _context.ReplaceCameraSmoothTime (0.3f);
        }

        public void Execute ()
        {
            _camera.position = Vector3.SmoothDamp (_camera.position, _target.position, ref _velocity, _context.cameraSmoothTime.value);
        }

    }
}