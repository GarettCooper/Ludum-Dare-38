using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PneuReplicatingBehaviour : DT.LogicalStateMachineBehaviour {

	public LayerMask layerMask;

	private float elapsedTime = 0;

	private Pneumonia pneu;
	private Vector3 direction;

	override protected void OnStateEntered() {
		pneu = Animator.GetComponent<Pneumonia>();
		elapsedTime = 0;

		direction = Random.insideUnitCircle.normalized;

	}

	override protected void OnStateExited() {
		
	}

	override protected void OnStateUpdated() {

		//Wander, from red blood cell code
		Animator.transform.Translate(direction * 0.002f);
		if (Animator.GetComponent<Collider2D>().IsTouchingLayers(layerMask)) direction = Random.insideUnitCircle.normalized;

		elapsedTime += Time.deltaTime;
		if (elapsedTime > pneu.replicationTime && GameObject.FindGameObjectsWithTag("Enemy").Length < 128) {
			//Potentially make this variable at some point, to prevent simultaneous replication waves
			elapsedTime = 0;
			GameObject temp = Instantiate(pneu.child);
			temp.transform.SetParent(Animator.transform.parent);
		}
	}

}
