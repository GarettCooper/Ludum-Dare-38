using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour {

	public int health;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void FixedUpdate() {
		if (health <= 0) {
			Death();
		}
	}

	private void Death() {
		
	}

	private void OnTriggerEnter2D(Collider2D other) {
		Debug.Log("Player hit");
		if(other.tag == "Enemy Projectile") {
			other.GetComponent<ProjectileMove>().Freeze(transform);
			health--;
		}
	}

}
