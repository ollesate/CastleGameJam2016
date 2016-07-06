using UnityEngine;
using System.Collections;

public class SpikeManager : MonoBehaviour {
	public void ChangeDimensions (bool is3d) {
		GameObject[] spikeArray = GameObject.FindGameObjectsWithTag("spike");
		
		foreach (GameObject spike in spikeArray) {
			if (is3d) {
				spike.GetComponent<Spikes>().SwitchTo3d ();
			} else {
				spike.GetComponent<Spikes>().SwitchTo2d ();
			}
		}
	}
}

