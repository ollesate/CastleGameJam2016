using UnityEngine;
using System.Collections;

public class RowSpawner : MonoBehaviour {

    private float width = 16f;
    public float spawnX;
    private float spawnWithinXDistance = 50f;
    public Transform target;
    private GameObject copyGameObject;

    void Start() {
        copyGameObject = gameObject;
    }
	
	// Update is called once per frame
	void Update () {
	    if (target.position.x > spawnX - spawnWithinXDistance) {
            spawnX += width;
            Vector3 spawnPos = transform.position + transform.right * spawnX;
            GameObject go = (GameObject)Instantiate(copyGameObject, spawnPos, transform.rotation);
            go.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            go.transform.parent = transform;
            go.GetComponent<RowSpawner>().enabled = false;
            copyGameObject = go;
        }
	}
}
