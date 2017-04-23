﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationBehaviour : MonoBehaviour {

	public GameObject obj;

	public float density;

	protected const int playAreaWidth = 60;   //Technically untrue, but simpler
	protected const int playAreaHeight = 40;
	protected int count;

	protected System.Random rand = new System.Random();

	// Use this for initialization
	void Start () {
		count = (int)(2 * playAreaWidth * 2 * playAreaHeight * density);
		GameObject temp; // For encapsulation
		for (int i = 0; i < count; i++) {
			obj.transform.position = new Vector2(rand.Next(-playAreaWidth, playAreaWidth), rand.Next(-playAreaHeight, playAreaHeight));
			temp = Instantiate(obj);
			temp.transform.SetParent(transform);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}