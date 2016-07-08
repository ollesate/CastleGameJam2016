using UnityEngine;
using System.Collections;

public class TorchSimulator : MonoBehaviour {

    private float startingIntensity = 3;
	
    void Start() {
        startingIntensity = GetComponent<Light>().intensity;
    }

	// Update is called once per frame
	void Update () {
        GetComponent<Light>().intensity = startingIntensity + (Mathf.Sin(Random.value));
	}
}
