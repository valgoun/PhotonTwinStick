using Photon;
using UnityEngine;

namespace TwinStick.Views
{
    public class BulletView : PunBehaviour
    {
        public override void OnPhotonInstantiate (PhotonMessageInfo info)
        {
            float speed = (float) GetComponent<PhotonView> ().instantiationData[0];
            GetComponent<Rigidbody> ().velocity = transform.forward * speed;
        }
    }
}