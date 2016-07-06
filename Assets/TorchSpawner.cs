using UnityEngine;
using System.Collections;

public class TorchSpawner : MonoBehaviour {

    public Transform torchesContainer;
    public GameObject torchPrefab;
    public Transform playerTransform;

    float requiredDistance = 50;

    float gap = 30;

    float distanceXLeft;
    float distanceXRight;

	// Use this for initialization
	void Start () {
        //distanceXLeft = playerTransform.position.x;
        distanceXRight = playerTransform.position.x;
    }
	
	// Update is called once per frame
	void Update () {
	    if (playerTransform.position.x > distanceXRight - requiredDistance) {
            SpawnTorchRight();
        }
	}

    void SpawnTorchRight() {
        GameObject go = (GameObject) Instantiate(torchPrefab, new Vector3(distanceXRight, transform.position.y, transform.position.z), transform.rotation);
        go.transform.parent = torchesContainer;
        distanceXRight += gap;
    }


}
