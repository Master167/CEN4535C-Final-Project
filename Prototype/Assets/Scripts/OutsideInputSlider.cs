using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OutsideInputSlider : MonoBehaviour {

	public Slider slider;
	public float level = 0.5f;

	private GameObject mainMenu;
	private float[] inputs = new float[10];

	void Start () {
		mainMenu = GameObject.Find("GameManager");
		MainMenu menu = mainMenu.GetComponent<MainMenu> ();
		if (menu.isHard) {
			level = 0.2f;
		} else {
			level = 0.5f;
		}
	}

	void FixedUpdate () {
		float input = Input.GetAxisRaw ("Vertical");
		if (input > 0f) {
			level = level + 0.01f;
			if (level > 1f) {
				level = 1;
			}
		} else if (input < 0) {
			level = level - 0.01f;
			if (level < 0) {
				level = 0;
			}
		}
	}

	void Update() {
		slider.normalizedValue = level;
	}

}
