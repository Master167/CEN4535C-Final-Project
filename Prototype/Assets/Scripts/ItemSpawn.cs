using UnityEngine;
using System.Collections;

public class ItemSpawn : MonoBehaviour {
	public float delay = 0.1f;
	public GameObject item;
	// Use this for initialization
	void Start () {
		InvokeRepeating("Spawn", delay, delay);
	
	}
	
	// Update is called once per frame
	void Spawn () {
		Instantiate(item, new Vector3(-1, 0, 0), Quaternion.identity);
	
	}
}
