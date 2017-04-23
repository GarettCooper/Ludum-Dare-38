using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneration : GenerationBehaviour {


	public int clusterNum;
	public int minClusterSize;
	public int maxClusterSize;
	public int clusterRadius;

	// Use this for initialization
	void Start () {
		rand = new System.Random();
		Vector2 clusterCentre;
		GameObject temp;
		int num;
		for (int i = 0; i < clusterNum; i++) {
			clusterCentre = new Vector2(rand.Next(-playAreaWidth + clusterRadius, playAreaWidth - clusterRadius), rand.Next(-playAreaHeight + clusterRadius, playAreaHeight - clusterRadius));
			num = rand.Next(minClusterSize, maxClusterSize);
			for (int j = 0; j < num; j++) {
				obj.transform.position = clusterCentre + Random.insideUnitCircle;
				temp = Instantiate(obj);
				temp.transform.SetParent(transform);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
