using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

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

	// Odd unresponsiveness to key release, look for source
	void Update () {

		verticalInput = Input.GetAxis("Vertical");
		horizontalInput = Input.GetAxis("Horizontal");

		direction.Set(horizontalInput * Time.deltaTime, verticalInput * Time.deltaTime);

		//Ensure Maximum Speed is maintained
		direction.Normalize();

		//Divide by 100 for consistency, but use more intuitive values in editor.
		direction *= (speed / 100);

		transform.Translate(direction);
	}
}
