using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PneuGotoBehaviour : DT.LogicalStateMachineBehaviour {

	private Pneumonia pneu;

	override protected void OnStateEntered() {
		pneu = Animator.GetComponent<Pneumonia>();
	}

	override protected void OnStateExited() {

	}

	override protected void OnStateUpdated() {
		pneu.transform.Translate(new Vector3(0, -1, 0) * -pneu.moveSpeed * Time.deltaTime);
	}
}
