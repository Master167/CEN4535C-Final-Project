using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OutsideInputSlider : MonoBehaviour {

	public Slider slider;
	public float level = 0.5f;

	private float[] inputs = new float[10];

	// Use this for initialization
	void Start () {
		//slider = (Slider) GameObject.Find ("Slider");
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
