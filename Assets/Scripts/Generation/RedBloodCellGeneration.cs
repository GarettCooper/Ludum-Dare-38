using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBloodCellGeneration : GenerationBehaviour {

	// Use this for initialization
	void Start() {
		rand = new System.Random();
		GameObject temp; // For encapsulation
		for (int i = 0; i < count; i++) {
			obj.transform.position = new Vector2(rand.Next(-playAreaWidth, playAreaWidth), rand.Next(-playAreaHeight, playAreaHeight));
			temp = Instantiate(obj);
			temp.transform.SetParent(transform);
		}
	}

	// Update is called once per frame
	void Update() {

	}
}
