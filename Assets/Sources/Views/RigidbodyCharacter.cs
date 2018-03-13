using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Quick Test not used in production
/// </summary>
public class RigidbodyCharacter : MonoBehaviour
{

	public float Speed = 5f;

	private Rigidbody _body;
	private Vector3 _inputs = Vector3.zero;

	void Start ()
	{
		_body = GetComponent<Rigidbody> ();
	}

	void Update ()
	{
		_inputs = Vector3.zero;
		_inputs.x = Input.GetAxis ("Horizontal");
		_inputs.z = Input.GetAxis ("Vertical");
	}

	void FixedUpdate ()
	{
		_body.MovePosition (_body.position + _inputs * Speed * Time.fixedDeltaTime);
	}
}