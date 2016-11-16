using UnityEngine;
using System.Collections;

public class ItemSpawn : MonoBehaviour {
	Random rnd = new Random ();

	public float delay = 5f; //randomize
	public GameObject item;
	// Use this for initialization
	void Start () {
		InvokeRepeating("Spawn", delay, delay);
	
	}
	
	// Update is called once per frame
	void Spawn () {
		Instantiate(item, new Vector3(5.64f, -0.13f, 0), Quaternion.identity);

	}

}
