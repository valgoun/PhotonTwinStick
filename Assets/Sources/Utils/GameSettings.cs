using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TwinStick.Utils
{
    [CreateAssetMenu (fileName = "GameSettings", menuName = "GameSettings")]
    public class GameSettings : ScriptableObject
    {
        public string GameVersion;
        public byte MaxPlayerPerRoom;
        public string LobbyScene;
    }
}