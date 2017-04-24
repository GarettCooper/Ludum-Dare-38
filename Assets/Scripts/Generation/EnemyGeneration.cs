using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneration : MonoBehaviour {

	public GameObject[] enemies;

	public int clusterNum;
	public int minClusterSize;
	public int maxClusterSize;
	public int clusterRadius;

	protected const int playAreaWidth = 55;   //Technically untrue, but simpler
	protected const int playAreaHeight = 35;
	protected int count;

	protected System.Random rand = Randomizer.random;

	private PopupText popup;

	void Start() {
		popup = GameObject.Find("PopupText").GetComponent<PopupText>();
		Init();
	}

	// Update is called once per frame
	void Update() {
		if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0) {
			popup.PushToScreen("Enemies Cleared, Repopulating...", 5);
			Init();
		}
	}

	private void Init() {
		Vector2 clusterCentre;
		GameObject obj;
		GameObject temp;
		int num;

		for (int i = 0; i < clusterNum; i++) {
			clusterCentre = new Vector2(rand.Next(5 * clusterRadius, playAreaWidth - clusterRadius) * (rand.NextDouble() > 0.5 ? 1 : -1), rand.Next(5 * clusterRadius, playAreaHeight - clusterRadius) * (rand.NextDouble() > 0.5 ? 1 : -1));
			num = rand.Next(minClusterSize, maxClusterSize);
			obj = enemies[rand.Next(0, enemies.Length)];
			for (int j = 0; j < num; j++) {
				obj.transform.position = clusterCentre + Random.insideUnitCircle;
				obj.transform.eulerAngles = new Vector3(0, 0, 360 * (float)rand.NextDouble());
				temp = Instantiate(obj);
				temp.transform.SetParent(GameObject.Find(obj.name).transform);
			}
		}
	}

}
