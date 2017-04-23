using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGeneration : GenerationBehaviour {

	public float maxLength;
	public float maxWidth;

	// Use this for initialization
	void Start () {
		count = (int)(2 * playAreaWidth * 2 * playAreaHeight * density);
		GameObject temp; // For encapsulation
		Vector2 size;
		for (int i = 0; i < count; i++) {
			obj.transform.position = new Vector2(rand.Next(-playAreaWidth, playAreaWidth), rand.Next(-playAreaHeight, playAreaHeight));
			size = new Vector2((float)rand.NextDouble() * maxLength, (float)rand.NextDouble() * maxWidth);
			obj.GetComponent<SpriteRenderer>().size = size;
			obj.GetComponent<BoxCollider2D>().size = size;
			obj.transform.localEulerAngles = new Vector3(0, 0, (float)rand.Next(4) * 90);
			temp = Instantiate(obj);
			temp.transform.SetParent(transform);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
