using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float jumpHeightForce;
	public GameObject outsideInput;

	private Rigidbody2D rb2d;
	private bool isGrounded;
	private float initialJumpHeightForce;

	// Use this for initialization
	void Start () {
		this.rb2d = GetComponent<Rigidbody2D> ();
		this.initialJumpHeightForce = jumpHeightForce;
	}
	
	// Update is called once per frame
	void Update () {
		OutsideInputSlider script = outsideInput.GetComponent<OutsideInputSlider> ();
		jumpHeightForce = initialJumpHeightForce * script.level;
		if (Input.GetKeyDown (KeyCode.Space) && isGrounded) {
			rb2d.AddForce(Vector2.up * jumpHeightForce);
			isGrounded = false;
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.CompareTag ("Ground")) {
			isGrounded = true;
		}
	}

	void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.CompareTag ("Collectible")) {
			Destroy (collision.gameObject, 0f);
		}
	}
}
