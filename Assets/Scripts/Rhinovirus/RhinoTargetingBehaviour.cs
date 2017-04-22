using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhinoTargetingBehaviour : DT.LogicalStateMachineBehaviour {

	private float angle;
	private Rhino rhino;

	override protected void OnStateEntered() {
		angle = Animator.transform.eulerAngles.z;
		rhino = Animator.GetComponent<Rhino>();
	}

	override protected void OnStateExited() {

	}

	override protected void OnStateUpdated() {
		angle += (rhino.rotationSpeed*Time.deltaTime);
		Animator.transform.localEulerAngles = new Vector3(Animator.transform.localEulerAngles.x, Animator.transform.localEulerAngles.y, angle);

		RaycastHit2D rch = Physics2D.Raycast(Animator.transform.FindChild("Horn").position,Animator.transform.eulerAngles,100000);
		//Debug.Log(rch.distance);
		//Debug.Log(rch.point);
		if (rch && rch.transform.tag == "Player") {
			Debug.Log("Charge");
			Animator.SetTrigger("Charge");
		}
	}

}
