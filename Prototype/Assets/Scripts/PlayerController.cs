using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float jumpHeightForce;

	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			rb2d.AddForce(Vector2.up * jumpHeightForce);
		}
	}
}
