using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour {

	private Button easyButton;
	private Button hardButton;
	private Button menuButton;
	private GameObject player;
	private Text timerText;
	private float score;
	private float currentTime;

	public bool isHard = true;
	public float maxTime = 120f;

	void Start () {
		Object.DontDestroyOnLoad (this);
	}

	void Update()
	{
		if (SceneManager.GetActiveScene().name == "MainScene")
		{
			UpdateTimer();
			// Gonna wait till player is on the ground before moving on
			if (currentTime == 0 && !player.GetComponent<PlayerController>().isAirbourne)
			{
				MoveToScoreboard();
			}
		}
	}

	// Use this to attach scene events
	void OnEnable() {
		SceneManager.sceneLoaded += setupScene;
	}

	// Use this to detach scene events
	void OnDisable() {
		SceneManager.sceneLoaded -= setupScene;
	}

	void setupScene(Scene scene, LoadSceneMode mode) {
		if (scene.name == "MainScene") {
			player = GameObject.Find ("Player");
			timerText = GameObject.Find("Timer").GetComponent<Text>();
			currentTime = maxTime;
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
		SceneManager.LoadScene("MainMenu");
	}

	void MoveToScoreboard()
	{
		score = player.GetComponent<PlayerController>().playerScore;
		SceneManager.LoadScene("Scoreboard");
	}

	void UpdateTimer()
	{
		currentTime = currentTime - Time.deltaTime;
		if (currentTime < 0)
		{
			currentTime = 0;
		}
		else if (currentTime < 30)
		{
			timerText.color = Color.red;
		}
		timerText.text = "Time: " + string.Format("{0}:{1:00}", (int)currentTime / 60, (int)currentTime % 60);
	}

}