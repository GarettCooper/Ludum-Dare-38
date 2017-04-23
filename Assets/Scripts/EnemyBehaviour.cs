using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

	public Sprite aliveSprite;
	public Sprite deadSprite;
	public int health;

	protected bool alive = true;

	protected Vector3 disToPlayer;

	internal GameObject player;

	protected Animator anim;
	protected int healthHash;
	protected int pdHash;


	// Use this for initialization
	protected void Start() {
		this.GetComponentInChildren<SpriteRenderer>().sprite = aliveSprite;
		anim = GetComponent<Animator>();
		healthHash = Animator.StringToHash("Health");
		pdHash = Animator.StringToHash("PlayerDist");
		player = GameObject.FindGameObjectWithTag("Player");
	}

	protected void FixedUpdate() {
		anim.SetInteger(healthHash, health);
		disToPlayer = transform.position - player.transform.position;
		anim.SetFloat(pdHash, disToPlayer.magnitude);
	}

	// Update is called once per frame
	protected void Update() {

	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.tag == "Projectile") {
			collision.GetComponent<ProjectileMove>().Freeze(transform);
			health--;
			if (health <= 0) Kill();
		} else if (collision.tag == "Enemy Projectile") {
			collision.GetComponent<ProjectileMove>().Freeze(transform,5);
		}
	}

	public bool Facing(GameObject target) {
		float angle = RelativeAngleTo(target);
		angle += transform.eulerAngles.z;
		return angle < 10 || angle > 350;
	}

	public float RelativeAngleTo(GameObject target) {
		//I definitely need to learn quaternions at some point
		Vector3 relativePos = transform.position - target.transform.position;

		float angle = (Mathf.Atan2(relativePos.x, relativePos.y) * Mathf.Rad2Deg);
		angle -= -1;
		angle = angle < 0 ? angle + 360 : angle;

		return angle;
	}

	void Kill() {
		alive = false;
		this.GetComponentInChildren<SpriteRenderer>().sprite = deadSprite;
		Destroy(gameObject, 10);
	}
}
