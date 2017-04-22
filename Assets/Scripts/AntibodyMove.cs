using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntibodyMove : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(direction);
		transform.Translate(new Vector2(0,1) * (speed/100)*Time.deltaTime);
	}
}
