using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pneumonia : EnemyBehaviour {

	public float replicationTime;
	public float moveSpeed;
	public float rotationSpeed;
	public float fireCooldownTime;

	internal GameObject child;
	internal int facingHash;

	// Use this for initialization
	new void Start () {
		base.Start();
		child = gameObject;
		facingHash = Animator.StringToHash("Facing");
	}

	internal void Fire() {
		GetComponentInChildren<RNAFire>().Fire();
		//projectile.transform.SetParent(GameObject.Find("RNA").transform);
	}

	new void FixedUpdate() {
		base.FixedUpdate();

		FacePlayer();
	}

	// Update is called once per frame
	new void Update () {
		base.Update();
		anim.SetBool(facingHash,Facing(player));
	}

	void FacePlayer() {

		Debug.Log("Face Player");

		Vector3 relativePos = transform.position - player.transform.position;

		float angle = (Mathf.Atan2(relativePos.x, relativePos.y) * Mathf.Rad2Deg);
		if (angle < 0) angle += 360;
		//angle;
		//Don't want to spend time determining why angle is inverted, negative is quickest fix
		transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, -angle + 180);
	}
}

