using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBloodCell : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.tag == "Projectile") {
			Debug.Log("Hit!");
			collision.GetComponent<AntibodyMove>().Freeze(transform,10);
		}
	}

}
