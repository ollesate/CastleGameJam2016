using UnityEngine;
using System.Collections;
using Assets.Scripts;


[RequireComponent (typeof(PerspectiveLerper))]
[RequireComponent(typeof(RotationLerper))]
[RequireComponent(typeof(PositionLerper))]
public class DimensionSwitchCamera : MonoBehaviour {

    private PositionLerper positionLerper;
    private PerspectiveLerper perspectiveLerper;
    private RotationLerper rotationLerper;

    public float animationDuration = .5f;
    private bool is3D = true;
    private bool isAnimating;

    private float initialY;
    private float initialXRotation;

    void Start () {
        Globals.Is3D = true;
        positionLerper = GetComponent<PositionLerper>();
        perspectiveLerper = GetComponent<PerspectiveLerper>();
        rotationLerper = GetComponent<RotationLerper>();

        initialY = transform.position.y;
        initialXRotation = transform.eulerAngles.x;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.H) && !isAnimating) {
            if (is3D) {
                switchTo2D();
            } else {
                switchTo3D();
            }
        }
	}
    
    public void switchTo2D() {
        Debug.Log("Switching to 2D");
        is3D = false;
        Globals.Is3D = false;

        positionLerper.LerpTo(new Vector3(transform.position.x, 0, transform.position.z), animationDuration);

        Vector3 euler = transform.rotation.eulerAngles;
        rotationLerper.LerpTo(new Vector3(0, euler.y, euler.z), animationDuration);

        perspectiveLerper.LerpToOrthographic(animationDuration);


        StartCoroutine(startAnimationStateProcess());
    }

    public bool IsAnimating() {
        return isAnimating;
    }

    public void switchTo3D() {
        Debug.Log("Switching to 3D" );
        is3D = true;
        Globals.Is3D = true;

        positionLerper.LerpTo(new Vector3(transform.position.x, initialY, transform.position.z), animationDuration);

        Vector3 euler = transform.rotation.eulerAngles;
        rotationLerper.LerpTo(new Vector3(initialXRotation, euler.y, euler.z), animationDuration);

        perspectiveLerper.LerpToPerspective(animationDuration);

        StartCoroutine(startAnimationStateProcess());
    }

    private IEnumerator startAnimationStateProcess() {
        isAnimating = true;
        yield return new WaitForSeconds(animationDuration);
        isAnimating = false;
    }
}
