using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;
using UnityEngine.UI;

namespace TwinStick.Launcher
{
	public class ModifyPseudoSystem : IInitializeSystem
	{
		private readonly InputField _field;
		private readonly GameContext _gameContext;

		public ModifyPseudoSystem (Contexts contexts, InputField associatedInputField)
		{
			_field = associatedInputField;
			_gameContext = contexts.game;
		}
		public void Initialize ()
		{
			_field.onValueChanged.AddListener (OnViewUpdate);
		}

		private void OnViewUpdate (string newPseudo)
		{
			_gameContext.ReplacePseudo (newPseudo);
		}
	}
}