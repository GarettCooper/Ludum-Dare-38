using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupText : MonoBehaviour {

	private float timeToClear = -1;
	private Text t;

	// Use this for initialization
	void Start () {
		t = gameObject.GetComponent<Text>();
		//Debug.Log(t);
	}
	
	// Update is called once per frame
	void Update () {
		timeToClear -= Time.deltaTime;
		if (timeToClear < 0) t.text = "";
	}

	public void PushToScreen(string message, float time) {
		t.text = message;
		t.enabled = true;
		timeToClear = time;
	}

}
