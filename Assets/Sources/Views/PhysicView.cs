using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;

/// <summary>
/// Utility that deactivate rigidbody when it's not owned
/// </summary>
public class PhysicView : UnityEngine.MonoBehaviour
{

    private Rigidbody _body;
    private PhotonView _networkView;

    private void Awake()
    {
        _body = GetComponent<Rigidbody>();
        _networkView = GetComponent<PhotonView>();
    }

    // Use this for initialization
    private void Start()
    {
        if(!_networkView.isMine)
        {
            _body.isKinematic = true;
        }
    }

    // Update is called once per frame
    private void Update()
    {

    }
}
