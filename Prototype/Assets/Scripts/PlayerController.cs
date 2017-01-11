using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float jumpHeightForce;
	public GameObject outsideInput;
	public float playerScore = 0;
	public bool isAirbourne;

	//Animation Variables
	Animator anim;
	public float jumpTime, jumpDelay = .5f;
	public bool jumped;

	private Rigidbody2D rb2d;
	private bool isGrounded;
	private float initialJumpHeightForce;

	// Use this for initialization
	void Start () {
		this.rb2d = GetComponent<Rigidbody2D> ();
		this.initialJumpHeightForce = jumpHeightForce;

		//Animations
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
		bool jumping = false;
		if (Input.GetKeyDown (KeyCode.Space)) {
			jumping = true;
		} else {
			foreach (Touch touch in Input.touches) {
				if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled) {
					jumping = true;	
				}
			}
		}
		OutsideInputSlider script = outsideInput.GetComponent<OutsideInputSlider> ();
		if (script != null) {
			jumpHeightForce = initialJumpHeightForce * script.level;
		} else {
			jumpHeightForce = initialJumpHeightForce * .5f;
		}
		if (jumping && isGrounded) {
			rb2d.AddForce(Vector2.down * jumpHeightForce);
			isGrounded = false;
			isAirbourne = true;

			//animation to change to jumping upon space bar
			jumpTime = jumpDelay;
			anim.SetTrigger ("jump");
			jumped = true;
		}


		//animation jumptimer
		jumpTime -= Time.deltaTime;
		if (jumpTime <= 0 && isGrounded && jumped) {
			anim.SetTrigger ("land");
			jumped = false;
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