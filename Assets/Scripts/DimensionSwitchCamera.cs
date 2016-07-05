using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class DimensionSwitchCamera : MonoBehaviour {

    private Camera cam;
    private Vector3 initialPosition;
    private Quaternion initialRotation;
	// Use this for initialization
	void Start () {
        Globals.Is3D = true;
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        cam = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
	    
        if (Input.GetKey(KeyCode.UpArrow)) {
            switchTo2D();
        } else if (Input.GetKey(KeyCode.DownArrow)) {
            switchTo3D();
        }

	}
    
    public void switchTo2D() {
        Globals.Is3D = false;
        cam.orthographic = true;
        Vector3 eulerRot = cam.transform.rotation.eulerAngles;
        cam.transform.rotation = Quaternion.Euler(new Vector3(0, eulerRot.y, eulerRot.z));
        Debug.Log("Switching to 2D euler" + eulerRot);
        
    }

    public void switchTo3D() {
        Globals.Is3D = true;
        cam.orthographic = false;
        cam.transform.rotation = initialRotation;
        Debug.Log("Switching to 3D euler" );
    }
}
