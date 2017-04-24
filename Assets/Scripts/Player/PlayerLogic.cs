using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLogic : MonoBehaviour {

	public int maxHealth;
	public int health;
	public AudioClip hurt;

	private StatTracker stats;
	private PopupText popup;
	private bool alive;
	

	// Use this for initialization
	void Start() {
		health = maxHealth;
		stats = GameObject.Find("Stats").GetComponent<StatTracker>();
		popup = GameObject.Find("PopupText").GetComponent<PopupText>();
		alive = true;
	}

	// Update is called once per frame
	void Update() {
		if (!alive) {
			if (Input.GetButton("Cancel")) SceneManager.LoadScene("Menu");
			else if (Input.GetButton("Restart")){
				Time.timeScale = 1;
				SceneManager.LoadScene("MainScene");
			}
		} else if (Input.GetButton("Cancel"))
			popup.PushToScreen("Are you sure you want to quit?\nPress Escape + Enter to confirm", 5);

		if (Input.GetButton("Cancel") && Input.GetButton("Submit")) SceneManager.LoadScene("Menu");
	}

	private void FixedUpdate() {
		stats.playerHealth = health;

		if (health <= 0) {
			Death();
		}
	}

	private void Death() {
		Debug.Log("Dead");
		alive = false;
		Time.timeScale = 0;
		popup.PushToScreen("You have died\nPress Escape to return to Menu or R to restart", 50);
	}

	private void OnTriggerEnter2D(Collider2D other) {
		//Debug.Log("Player hit");
		if (other.tag == "Enemy Projectile") {
			other.GetComponent<ProjectileMove>().Freeze(transform);
			AudioSource.PlayClipAtPoint(hurt, transform.position);
			health--;
		}
	}

}
