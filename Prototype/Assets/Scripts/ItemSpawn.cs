using UnityEngine;
using System.Collections;
using System;

public class ItemSpawn : MonoBehaviour {
	public GameObject item;

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

		Instantiate(item, new Vector3(5.64f, -0.13f, 0), Quaternion.identity);


	}

	//Sets the random time between minTime and maxTime
	void SetRandomTime(){
		spawnTime = UnityEngine.Random.Range(minTime, maxTime);
	}

}



