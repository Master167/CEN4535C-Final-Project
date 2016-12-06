using UnityEngine;
using System.Collections;
using System;

public class ItemSpawn : MonoBehaviour {
	public GameObject topTier;
	public GameObject middleTier;
	public GameObject bottomTier;

	public float topTierYOffset = 1.43f;
	public float middleTierYOffset = 0.57f;
	public float bottomTierYOffset = -1.75f;

	public float maxTime = 30f;
	public float minTime = 5f;

	public int topTiercount;
	public int middleTiercount;
	public int bottomTiercount;

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

		//spwann at different times and spawn so max number of items on screen. 
		int randomTierSpawn = UnityEngine.Random.Range(1,4);

		switch (randomTierSpawn) {
		case 1:
					Instantiate (topTier, new Vector3 (10f, transform.position.y + topTierYOffset, 0), Quaternion.identity);
			        break;

		case 2:
			Instantiate (middleTier, new Vector3 (10f, transform.position.y + middleTierYOffset, 0), Quaternion.identity);
			break;

		case 3:
			Instantiate (bottomTier, new Vector3 (10f, transform.position.y + bottomTierYOffset, 0), Quaternion.identity);
			break;
		}
		
	}

	//Sets the random time between minTime and maxTime
	void SetRandomTime(){
		spawnTime = UnityEngine.Random.Range(minTime, maxTime);
	}

}



