using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using System.Collections;

public class MainMenu : MonoBehaviour {

	private Button easyButton;
	private Button hardButton;
	private GameObject player;

	public bool isHard = true;

	// Use this for initialization
	void Start () {
		Object.DontDestroyOnLoad (this);
		Scene scene = SceneManager.GetActiveScene();
		if (scene.name == "MainMenu") {
			easyButton = GameObject.Find ("Easy").GetComponent<Button> ();
			hardButton = GameObject.Find ("Hard").GetComponent<Button> ();
			easyButton.onClick.AddListener (loadEasy);
			hardButton.onClick.AddListener (loadHard);
		}
	}

	// Use this to attach scene events
	void OnEnable() {
		SceneManager.sceneLoaded += getPlayerObject;
		SceneManager.sceneUnloaded += getScore;
	}

	// Use this to detach scene events
	void OnDisable() {
		SceneManager.sceneLoaded -= getPlayerObject;
		SceneManager.sceneUnloaded -= getScore;
	}

	void getPlayerObject(Scene scene, LoadSceneMode mode) {
		if (scene.name == "MainScene") {
			player = GameObject.Find ("Player");
			Debug.Log ("Got Player");
		}
	}

	void getScore(Scene scene) {
		if (scene.name == "MainScene") {
			Debug.Log ("pulling score");
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

}
