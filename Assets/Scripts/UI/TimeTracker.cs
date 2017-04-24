using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

using UnityEngine.UI;

public class TimeTracker : MonoBehaviour {

	private Stopwatch stopwatch;
	private Text text;
	// Use this for initialization
	void Start() {
		stopwatch = new Stopwatch();
		stopwatch.Start();
		text = GetComponent<Text>();
	}

	// Update is called once per frame
	void Update() {

		if (Time.timeScale == 0) stopwatch.Stop();
		else stopwatch.Start();

		TimeSpan time = TimeSpan.FromMilliseconds(stopwatch.ElapsedMilliseconds);
		//UnityEngine.Debug.Log(time);
		text.text = string.Format("{0:00}:{1:00}:{2:00}", time.Hours, time.Minutes, time.Seconds);
	}
}
