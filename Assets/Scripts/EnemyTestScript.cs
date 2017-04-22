using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTestScript : MonoBehaviour {

	public Sprite aliveSprite;
	public Sprite deadSprite;
	public int health;

	bool alive = true;

	// Use this for initialization
	void Start() {
		this.GetComponent<SpriteRenderer>().sprite = aliveSprite;
	}

	private void FixedUpdate() {

	}

	// Update is called once per frame
	void Update() {

	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.tag == "Projectile") {
			Debug.Log("Hit!");
			collision.GetComponent<AntibodyMove>().Freeze(transform);
			health--;
			if(health <= 0) Kill();
		}
	}

	void Kill() {
		alive = false;
		this.GetComponent<SpriteRenderer>().sprite = deadSprite;
		Destroy(gameObject, 10);
	}
}
