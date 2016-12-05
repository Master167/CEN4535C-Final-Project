using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OutsideInputSlider : MonoBehaviour {

	public Slider slider;
	public float level = 0.5f;

	private GameObject mainMenu;
	private float[] inputs = {-1f, -1f, -1f, -1f, -1f, -1f, -1f, -1f, -1f, -1f};
	private int index = 0;
	private bool isHard;

	void Start () {
		mainMenu = GameObject.Find("GameManager");
		MainMenu menu = mainMenu.GetComponent<MainMenu> ();
		if (menu.isHard) {
			this.inputs[this.index] = 0.2f;
		} else {
			this.inputs[this.index] = 0.5f;
		}
		this.isHard = menu.isHard;
		// For testing
		//this.inputs[this.index] = 0.5f;
		this.isHard = false;
		InvokeRepeating ("GetInput", 0f, 1.0f);
	}

	void Update() {
		level = normalizeLevel ();
		slider.normalizedValue = level;
	}

	void GetInput() {
		float input = Input.GetAxisRaw ("Vertical");
		float s;
		float currentLevel = this.level;

		if (isHard) {
			s = 0.05f;
		} else {
			s = 0.1f;
		}

		if (input > 0f) {			
			currentLevel = currentLevel + s;
			if (currentLevel > 1f) {
				currentLevel = 1;
			}
		} else if (input < 0) {
			if (isHard) {
				s = s * 2;
			}
			currentLevel = currentLevel - s;
			if (currentLevel < 0) {
				currentLevel = 0;
			}
		}
		this.index = (index + 1) % this.inputs.Length;
		this.inputs [this.index] = currentLevel;

	}

	float normalizeLevel() {
		int values = 1;
		float total = this.inputs[this.index];
		for (int i = 0; i < inputs.Length; i++) {
			if (inputs [i] >= 0 && i != this.index) {
				total += inputs [i];
				values++;
			}
		}

		return total / values;
	}

}
