using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntibodyMove : MonoBehaviour {

	public float speed;
	public bool canMove = true;

	// Use this for initialization
	void Start() {

	}

	// Update is called once per frame
	void Update() {
		//Debug.Log(direction);
		if(canMove) transform.Translate(new Vector2(0, 1) * (speed / 100) * Time.deltaTime);
	}

	public void Freeze(Transform t) {
		canMove = false;
		transform.SetParent(t);
		GetComponent<Collider2D>().isTrigger = false;
		Destroy(gameObject, 10);
	}
}
