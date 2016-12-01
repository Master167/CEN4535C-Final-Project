using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float jumpHeightForce;
	public GameObject outsideInput;
	public float playerScore = 0;
    public bool isAirbourne;

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
		if (script != null) {
			jumpHeightForce = initialJumpHeightForce * script.level;
		} else {
			jumpHeightForce = initialJumpHeightForce * .5f;
		}
		if (Input.GetKeyDown (KeyCode.Space) && isGrounded) {
			rb2d.AddForce(Vector2.up * jumpHeightForce);
			isGrounded = false;
            isAirbourne = true;
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.CompareTag ("Ground")) {
			isGrounded = true;
            isAirbourne = false;
		}
	}

	void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.CompareTag ("Collectible")) {
			Item item = collision.gameObject.GetComponent<Item> ();
			if (item != null) {
				playerScore += item.score;
			}
			Destroy (collision.gameObject, 0f);
		}
	}
}
