using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {
	public float lifetime = .1f;
	private float speed = Random.Range(.01f, .06f);

	// Use this for initialization
	void Start () {
		Destroy (gameObject, lifetime);
	
	}
	
	// Update is called once per frame
    void Update() {
			transform.Translate(-speed, 0, 0);
			
	}
	

}
