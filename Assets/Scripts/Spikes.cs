using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour {

    public float speed = 7.0f;
    private float initialY;
	Collider[] colliders;
	float[] sizes = {55,1600};

    void Start()
    {
        initialY = transform.position.y;
		colliders = this.GetComponents<BoxCollider> ();
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;

        float ySin = Mathf.Sin(Time.time*speed)*0.1f;

        gameObject.transform.position = new Vector3(pos.x, initialY + ySin, pos.z);
	}

	void ChangeDimensions (bool is3d, float size){
		foreach (BoxCollider collider in colliders){
			collider.size = new Vector3 (collider.size.x, size, collider.size.z);
		}
	}

	public void SwitchTo2d(){
		ChangeDimensions (false, sizes[1]);
	}
		
	public void SwitchTo3d(){
		ChangeDimensions (true, sizes[0]);
	}
}
