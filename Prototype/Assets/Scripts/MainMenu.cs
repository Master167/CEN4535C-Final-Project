using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using System.Collections;

public class MainMenu : MonoBehaviour {

	private Button easyButton;
	private Button hardButton;
	private Button menuButton;
	private GameObject player;
	private float score;

	public bool isHard = true;

	// Use this for initialization
	void Start () {
		Object.DontDestroyOnLoad (this);
	}

	// Use this to attach scene events
	void OnEnable() {
		//SceneManager.sceneLoaded += getObjects;
		//SceneManager.sceneUnloaded += getScore;
	}

	// Use this to detach scene events
	void OnDisable() {
		//SceneManager.sceneLoaded -= getObjects;
		//SceneManager.sceneUnloaded -= getScore;
	}

	void getObjects(Scene scene, LoadSceneMode mode) {
		if (scene.name == "MainScene") {
			player = GameObject.Find ("Player");
		} else if (scene.name == "Scoreboard") {
			menuButton = GameObject.Find ("MenuButton").GetComponent<Button> ();
			menuButton.onClick.AddListener (MoveToMenu);
			GameObject.Find ("Score").GetComponent<Text> ().text = "Final Score: " + score;
		} else if (scene.name == "MainMenu") {
			easyButton = GameObject.Find ("Easy").GetComponent<Button> ();
			hardButton = GameObject.Find ("Hard").GetComponent<Button> ();
			easyButton.onClick.AddListener (loadEasy);
			hardButton.onClick.AddListener (loadHard);
		}
	}

	void getScore(Scene scene) {
		if (scene.name == "MainScene") {
			score = player.GetComponent<PlayerController> ().playerScore;
		}
	}

	void loadEasy() {
		isHard = false;
		MoveToMainScene ();
	}

	void loadHard() {
		isHard = true;
		MoveToMainScene ();
	}

	void MoveToMainScene() {
		SceneManager.LoadScene ("MainScene");
	}

	void MoveToMenu() {
		Debug.Log ("Hello");
	}

}
