using UnityEngine;
using System.Collections;

public class TorchSimulator : MonoBehaviour {

    public int startingIntensity = 3;
	
	// Update is called once per frame
	void Update () {
        GetComponent<Light>().intensity = startingIntensity + (Mathf.Sin(Random.value));
	}
}
