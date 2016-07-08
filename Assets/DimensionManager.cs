using UnityEngine;
using System.Collections;

public class DimensionManager : MonoBehaviour {

    public PlatformManager platformManager;
    public DimensionSwitchCamera dimensionCamera;
	public SpikeManager spikeManager;
	public PlayerControll player;
    public PlatformSpawner platformSpawner;

    public bool is3D = true;

	// Use this for initialization
	void Start () {
	    if (platformManager == null) {
            Debug.LogError("Dimension manager needs a platform manager to switch behaviour on platforms");
        }
        if (dimensionCamera == null) {
            Debug.LogError("Dimension manager needs a dimension camera to animate between 2D and 3D");
        }
		if (spikeManager == null) {
			Debug.LogError("Dimension manager needs a spike manager to switch behaviour on spikes");
		}
		if (player == null) {
			Debug.LogError("Dimension manager needs a player");
		}
        if (platformSpawner == null) {
            Debug.LogError("Dimension manager needs a platform spawner to switch spawn platforms with the right perspective");
        }

	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetButton("Fire2") && !dimensionCamera.IsAnimating()) {
            ChangeDimension();
        }
	}

    public void ChangeDimension() {
        is3D = !is3D;
        platformManager.ChangeDimensions(is3D);
        dimensionCamera.ChangeDimensions(is3D);
        spikeManager.ChangeDimensions(is3D);
        player.ChangeDimensions(is3D);
        platformSpawner.ChangeDimensions(is3D);
    }
}
