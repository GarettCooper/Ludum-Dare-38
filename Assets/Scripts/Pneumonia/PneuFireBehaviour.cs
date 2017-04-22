using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PneuFireBehaviour : DT.LogicalStateMachineBehaviour {

	private Pneumonia pneu;
	private float cooldown;

	override protected void OnStateEntered() {
		pneu = Animator.GetComponent<Pneumonia>();
		cooldown = 0;
	}

	override protected void OnStateExited() {

	}

	override protected void OnStateUpdated() {
		cooldown -= Time.deltaTime;
		if (cooldown <= 0) {
			cooldown = pneu.fireCooldownTime;
			pneu.Fire();
		}
	}
}
