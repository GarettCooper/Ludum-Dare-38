using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.tag.Contains("Projectile")) {
			Debug.Log("Hit!");
			collision.GetComponent<ProjectileMove>().Freeze(transform, 10);
		}
	}

}
