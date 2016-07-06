using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlatformSpawner : MonoBehaviour {

    public Transform player;
    public GameObject[] platforms;

    private float step = 14;
    private float initialZ;

    private float spawnDistance = 20;

	// Use this for initialization
	void Start () {
        initialZ = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
        if (player.position.x > transform.position.x - spawnDistance) {
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
