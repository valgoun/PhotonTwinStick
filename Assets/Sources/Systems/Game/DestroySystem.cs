using Entitas;
using Photon;
using UnityEngine;

namespace TwinStick.Game
{
    public class DestroySystem : IInitializeSystem, ICleanupSystem
    {
        private readonly GameContext _context;
        private IGroup<GameEntity> _entitiesToDestroy;

        public DestroySystem (Contexts contexts)
        {
            _context = contexts.game;
        }
        public void Initialize ()
        {
            _entitiesToDestroy = _context.GetGroup (GameMatcher.AllOf (GameMatcher.MarkForDeletion, GameMatcher.GameView));
        }
        public void Cleanup ()
        {
            foreach (var e in _entitiesToDestroy.GetEntities ())
            {
                if (e.hasPhotonView)
                {
                    if (e.photonView.photonView.isMine)
                    {
                        PhotonNetwork.Destroy (e.gameView.gameObject);
                        e.Destroy ();
                    }
                }
                else
                {
                    GameObject.Destroy (e.gameView.gameObject);
                    e.Destroy ();
                }
            }
        }

    }
}