using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class UserInterface : MonoBehaviour {

	public Text score;
	public string scorePrefix;

	private GameObject player;
	private float floatScore;

	void Start() {
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		PlayerController controller = player.GetComponent<PlayerController> ();
		if (controller != null) {
			floatScore = controller.playerScore;
		}
		score.text = scorePrefix + " " + floatScore.ToString("#0");
	}
}
