using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

	private float speed = Random.Range(.01f, .06f);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    void Update() {
			transform.Translate(-speed, 0, 0);
			
	}
	

}
