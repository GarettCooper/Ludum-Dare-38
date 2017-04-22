using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rhino : EnemyBehaviour {

	public float rotationSpeed;

	protected Vector3 disToPlayer;

	internal GameObject player;

	private Animator anim;
	private int healthHash;
	

	// Use this for initialization
	new void Start() {
		base.Start();
		anim = GetComponent<Animator>();
		healthHash = Animator.StringToHash("Health");
		player = GameObject.FindGameObjectWithTag("Player");
	}

	new void FixedUpdate() {
		base.FixedUpdate();

		anim.SetInteger(healthHash, health);
		disToPlayer = transform.position - player.transform.position;

	}

	// Update is called once per frame
	new void Update () {
		base.Update();

	}
}
