using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour {

	public float speed;

	private float verticalInput;
	private float horizontalInput;
	private Vector2 direction;

	// Use this for initialization
	void Start () {
		direction = new Vector3();
	}

	void FixedUpdate() {
		
		
	}

	// Update is called once per frame
	void Update () {

		verticalInput = Input.GetAxis("Vertical");
		horizontalInput = Input.GetAxis("Horizontal");

		direction.Set(horizontalInput * Time.deltaTime, verticalInput * Time.deltaTime);
		direction.Normalize();
		direction *= speed;
		
		transform.Translate(direction);
	}
}
