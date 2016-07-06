using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlatformSpawner : MonoBehaviour {

    public Transform player;
    public GameObject spawn1;
    public GameObject[] platforms;

    private float step = 14;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.P)) {
            SpawnRandom();
        }
	}

    public void SpawnRandom() {
        int randIndex = Random.Range(0, platforms.Length);
        Spawn(platforms[randIndex]);
    }

    void Next() {
        transform.position += transform.right * step;
    }

    void Spawn(GameObject go) {
        Next();
        GameObject spawn = (GameObject)Instantiate(go, transform.position, transform.rotation);
        spawn.transform.parent = transform.parent;
    }
}
