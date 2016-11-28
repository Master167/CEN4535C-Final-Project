using UnityEngine;
using System.Collections;
using System;

public class ItemSpawn : MonoBehaviour {
	public GameObject topTier;
	public GameObject middleTier;
	public GameObject bottomTier;

	public float topTierYOffset = 1.43f;
	public float middleTierYOffset = 0.57f;
	public float bottomTierYOffset = -1.43f;

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

		Instantiate(topTier, new Vector3(10f, transform.position.y + topTierYOffset, 0), Quaternion.identity);
		Instantiate(middleTier, new Vector3(10f, transform.position.y + middleTierYOffset, 0), Quaternion.identity);
		Instantiate(bottomTier, new Vector3(10f, transform.position.y + bottomTierYOffset, 0), Quaternion.identity);
	}

	//Sets the random time between minTime and maxTime
	void SetRandomTime(){
		spawnTime = UnityEngine.Random.Range(minTime, maxTime);
	}

}



