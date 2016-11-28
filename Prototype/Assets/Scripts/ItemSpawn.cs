using UnityEngine;
using System.Collections;
using System;

public class ItemSpawn : MonoBehaviour {
	public GameObject topTier;
	public GameObject middleTier;
	public GameObject bottomTier;

	public float maxTime = 30f;
	public float minTime = 5f;


	//current time
	private float time;


	//The time to spawn the object
	private float spawnTime;

	void Start(){
		SetRandomTime();
		time = minTime;

	}

	void FixedUpdate(){

		//Counts up
		time += Time.deltaTime;

		//Check if its the right time to spawn the object
		if(time >= spawnTime){
			Spawn();
			SetRandomTime();
		}

	}


	//Spawns the object and resets the time
	void Spawn(){
		time = 0;

		Instantiate(topTier, new Vector3(5.64f, -0.13f, 0), Quaternion.identity);
		Instantiate(middleTier, new Vector3(5.64f, -3.13f, 0), Quaternion.identity);

	}

	//Sets the random time between minTime and maxTime
	void SetRandomTime(){
		spawnTime = UnityEngine.Random.Range(minTime, maxTime);
	}

}



