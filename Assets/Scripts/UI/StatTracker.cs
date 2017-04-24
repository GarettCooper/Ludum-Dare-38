using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatTracker : MonoBehaviour {

	[System.NonSerialized]
	public int enemiesKilled;

	[System.NonSerialized]
	public int playerHealth;

	private Text text;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = string.Format("Enemies Killed: {0}\nHealth: {1:00}",enemiesKilled,playerHealth);
	}
}
