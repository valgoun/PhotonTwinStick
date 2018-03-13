using Entitas;
using UnityEngine;

namespace TwinStick.Utils
{
    /// <summary>
    /// System that sets the ViewRootGameObject Components
    /// </summary>
    public class CreateViewRootGameObjectSystem : IInitializeSystem
    {
        private readonly Contexts _contexts;
        private readonly GameObject _viewRootGameObject;
        public CreateViewRootGameObjectSystem (Contexts contexts, GameObject ViewRootGameObject)
        {
            _contexts = contexts;
            _viewRootGameObject = ViewRootGameObject;
        }
        public void Initialize ()
        {
            _contexts.game.ReplaceViewRootGameOject (_viewRootGameObject);
            _contexts.input.ReplaceViewRootGameOject (_viewRootGameObject);
            _contexts.network.ReplaceViewRootGameOject (_viewRootGameObject);
            _contexts.uI.ReplaceViewRootGameOject (_viewRootGameObject);
        }
    }
}