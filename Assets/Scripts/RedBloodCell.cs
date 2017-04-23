using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBloodCell : MonoBehaviour {

	public float driftSpeed;
	public LayerMask layerMask;

	private Vector2 direction;

	// Use this for initialization
	void Start () {
		direction = Random.insideUnitCircle;
	}

	private void FixedUpdate() {
		transform.Translate(direction * (driftSpeed/100));
		if(GetComponent<Collider2D>().IsTouchingLayers(layerMask)) direction = Random.insideUnitCircle;
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
