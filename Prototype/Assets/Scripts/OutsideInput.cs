using UnityEngine;
using System.Collections;

public class OutsideInput : MonoBehaviour {

    public string deviceName;
    public float level;

    private AudioSource source;
    
	void Start () {
        //source = GetComponent<AudioSource>();
        //source.clip = Microphone.Start(null, true, 10, 44100);
        //source.loop = true;
        //source.mute = true;
        //while (!(Microphone.GetPosition(null) > 0))
        //{
        //}
        //source.Play();
        
	}
	
	// Update is called once per frame
	void Update () {
        //level = GetInputLevel() * 100;
	}

    public float GetInputLevel()
    {
        //float[] data = new float[256];
        //float average = 0;
        //source.GetOutputData(data, 0);
        //foreach (float f in data)
        //{
        //    average += Mathf.Abs(f);
        //}
        //return average / data.Length;
		return 0.0f;
        
    }
}
