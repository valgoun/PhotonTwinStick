using UnityEngine;

namespace TwinStick.Utils
{
    /// <summary>
    /// Scriptable Object to store input settings
    /// </summary>
    [CreateAssetMenu (fileName = "InputSettings", menuName = "InputSettings")]
    public class InputSettings : ScriptableObject
    {
        [Header ("Move input")]
        public string XAxisName;
        public string YAxisName;
        [Header ("Reload input"), Tooltip ("Maximum delay between two clicks to perform the Reload action (in milliseconds)")]
        public float DoubleClickDelay = 250;
    }
}