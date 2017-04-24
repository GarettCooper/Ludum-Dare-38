using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public GameObject obj;
	public int objCount;

	private Canvas sizeReference;

	void Start () {
	}
	
	void Update () {
		if (Input.GetButton("Cancel")) Application.Quit();
		if (Input.GetButton("Submit")) SceneManager.LoadScene("MainScene");
	}

}
