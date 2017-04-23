using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntibodySpawnerControl : MonoBehaviour {

	public float cooldownTime;
	public GameObject antibody;

	private float radius;
	private float cooldown;
	// Use this for initialization
	void Start() {
		radius = transform.localPosition.magnitude;
		//Debug.Log(radius);
	}

	// Update is called once per frame
	void Update() {
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePos -= transform.position;
		//float mouseX = Input.GetAxis("Mouse X");
		//float mouseY = Input.GetAxis("Mouse Y");

		float angle = (Mathf.Atan2(mousePos.x, mousePos.y) * Mathf.Rad2Deg);
		if (angle < 0) angle += 360;
		angle *= -1;
		//Don't want to spend time determining why angle is inverted, negative is quickest fix
		transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, angle);

		//Adding 90 means this is probably reversed, but I don't want to spend time testing when this works fine.
		Vector2 position = new Vector2(Mathf.Cos((angle + 90) * Mathf.Deg2Rad) * radius, Mathf.Sin((angle + 90) * Mathf.Deg2Rad) * radius);
		transform.localPosition = position;

		cooldown -= Time.deltaTime;

		// This should probably have it's own method for internal consistency, but I don't want to take the time.
		if (Input.GetButton("Fire1") && cooldown < 0) {
			Debug.Log("Fire Antibody");
			cooldown = cooldownTime;
			antibody.transform.eulerAngles = transform.eulerAngles;
			antibody.transform.position = transform.position;		
			GameObject temp = Instantiate(antibody);
			temp.transform.SetParent(GameObject.Find("Antibodies").transform);
		}
	}
}
