using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {
	
	private float speed;


	void Start() {
		this.speed = Random.Range (.01f, .06f);
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
