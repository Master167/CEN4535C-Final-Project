using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {
	private float lifetime = 15.0f;

	void Start(){
	
		Destroy (gameObject,lifetime);
	}
}
