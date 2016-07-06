using UnityEngine;
using System.Collections;

public class DimensionManager : MonoBehaviour {

    public PlatformManager platformManager;
    public DimensionSwitchCamera dimensionCamera;
	public SpikeManager spikeManager;

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

	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.H) && !dimensionCamera.IsAnimating()) {
            is3D = !is3D;
            platformManager.ChangeDimensions(is3D);
            dimensionCamera.ChangeDimensions(is3D);
			spikeManager.ChangeDimensions (is3D);
        }
	}
}
