using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TwinStick.Utils
{
    /// <summary>
    /// Scriptable object to store game settings
    /// </summary>
    [CreateAssetMenu (fileName = "GameSettings", menuName = "GameSettings")]
    public class GameSettings : ScriptableObject
    {
        public string GameVersion;
        public byte MaxPlayerPerRoom;
        public string LobbyScene;
    }
}