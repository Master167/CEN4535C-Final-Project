using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

	public float speed;
	public float score;

	void Start() {
		

	}

    void Update() {

		transform.Translate(-speed, 0, 0);
			
	}
	
	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.CompareTag ("Player")) {
			Destroy (gameObject, 0f);
		}
	}
}
