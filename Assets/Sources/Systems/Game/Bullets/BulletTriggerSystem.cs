using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace TwinStick.Game
{
    /// <summary>
    /// The system react to bullet being triggered.
    /// It marks for deletion
    /// It clean the bullet trigger component
    /// </summary>
    public class BulletTriggerSystem : ReactiveSystem<GameEntity>, ICleanupSystem, IInitializeSystem
    {

        private readonly GameContext _context;

        private IGroup<GameEntity> _triggeredBullets;

        public BulletTriggerSystem (Contexts contexts) : base (contexts.game)
        {
            _context = contexts.game;
        }
        public void Initialize ()
        {
            _triggeredBullets = _context.GetGroup (GameMatcher.BulletTriggerEnter);
        }
        protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
        {
            return context.CreateCollector (GameMatcher.BulletTriggerEnter);
        }

        protected override bool Filter (GameEntity entity)
        {
            return entity.hasBulletTriggerEnter;
        }

        protected override void Execute (List<GameEntity> entities)
        {
            foreach (var e in entities)
            {
                e.isMarkForDeletion = true;
            }
        }

        public void Cleanup ()
        {
            foreach (var e in _triggeredBullets.GetEntities ())
            {
                e.RemoveBulletTriggerEnter ();
            }
        }

    }
}