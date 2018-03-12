using UnityEngine;

namespace TwinStick.Views
{
    public class RotatingSprite : MonoBehaviour
    {
        public float RotationSpeed;
        void Update ()
        {
            transform.Rotate (0, 0, RotationSpeed * -Time.deltaTime);
        }

    }
}