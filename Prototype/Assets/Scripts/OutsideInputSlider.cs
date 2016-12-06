using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OutsideInputSlider : MonoBehaviour {

	public Slider slider;
	public float level = 0.5f;

	private GameObject mainMenu;
	private float[] inputs = {0.5f, 0.5f, -1f, -1f, -1f, -1f, -1f, -1f, -1f, -1f};
	private int index = 0;
	private bool isHard;

    // Simulate the DataStream from the Meter
    private float[] data = { 0.5f, 0.5f, 0.5f, 0.6f, 0.6f, 0.6f, 0.7f, 0.7f, 0.7f, 0.8f, 0.8f, 0.8f, 0.9f, 0.9f, 0.9f, 1f, 1f, 1f, 0.8f, 0.8f, 0.7f, 0.7f, 0.6f, 0.6f, 0.5f, 0.5f, 0.4f, 0.4f, 0.3f, 0.2f };
    private int dataIndex;

	void Start () {
        this.dataIndex = 0;
		mainMenu = GameObject.Find("GameManager");
		MainMenu menu = mainMenu.GetComponent<MainMenu> ();
        slider.normalizedValue = normalizeLevel();
        this.isHard = menu.isHard;
		InvokeRepeating ("GetInput", 0f, 1.0f);
	}

	void Update() {
        level = normalizeLevel ();
        slider.normalizedValue = level;
	}

	void GetInput() {
		float previousInput;
		float s;
		float newInput;
        float result;

        previousInput = this.data[dataIndex];
        dataIndex = (dataIndex + 1) % this.data.Length;
        newInput = this.data[dataIndex];

		if (isHard) {
			s = 0.5f;
		} else {
			s = 1f;
		}

        if (previousInput > newInput && isHard)
        {
            s = s * 2;
        }
        result = newInput * s;

        this.index = (index + 1) % this.inputs.Length;
		this.inputs [this.index] = result;

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
