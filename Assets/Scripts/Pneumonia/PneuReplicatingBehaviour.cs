using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PneuReplicatingBehaviour : DT.LogicalStateMachineBehaviour {

	private float elapsedTime = 0;

	private Pneumonia pneu;

	override protected void OnStateEntered() {
		pneu = Animator.GetComponent<Pneumonia>();
		elapsedTime = 0;
	}

	override protected void OnStateExited() {
		
	}

	override protected void OnStateUpdated() {
		elapsedTime += Time.deltaTime;
		if (elapsedTime > pneu.replicationTime && GameObject.FindGameObjectsWithTag("Enemy").Length < 128) {
			//Potentially make this variable at some point, to prevent simultaneous replication waves
			elapsedTime = 0;
			Instantiate(pneu.child);
		}
	}

}
