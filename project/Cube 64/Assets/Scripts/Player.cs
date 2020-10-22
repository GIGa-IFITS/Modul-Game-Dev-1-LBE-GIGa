using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	[SerializeField] private float speed = 5;

	private Vector3 dir;
	private Rigidbody rb;

	private int coin = 0;
	public int Coin {
		get {
			return coin;
		}
		set {
			coin = value;
		}
	}

	private void Start() {
		rb = GetComponent<Rigidbody>();
	}

	private void Update() {
		InputHandling();
	}

	private void InputHandling() {
		dir.x = Input.GetAxis("Horizontal");
		dir.z = Input.GetAxis("Vertical");
	}

	private void FixedUpdate() {
		if(dir != Vector3.zero) {
			RotatePlayerFaceToDir();
		}
		MovePlayerToDir();
	}

	private void RotatePlayerFaceToDir() {
		Quaternion newRotation = Quaternion.LookRotation(dir);
		transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, .1f);
	}

	private void MovePlayerToDir() {
		Vector3 velocity = dir * speed;
		velocity.y = rb.velocity.y;
		rb.velocity = velocity;
	}

}
