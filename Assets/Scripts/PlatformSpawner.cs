using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlatformSpawner : MonoBehaviour {

    public Transform player;
    public GameObject[] platforms;

    private float step = 14;
    private float initialZ;
    private float deltaZ = 5;

    private float spawnDistance = 20;

    private bool is3D;

	// Use this for initialization
	void Start () {
        initialZ = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
        if (player.position.x > transform.position.x - spawnDistance) {
            float randomZ = Random.Range(-deltaZ, deltaZ) + initialZ;
            SpawnRandom(randomZ);
        }
	}

    public void SpawnRandom(float zPosition) {
        int randIndex = Random.Range(0, platforms.Length);
        Spawn(platforms[randIndex], zPosition);
    }

    void Next() {
        transform.position += transform.right * step;
    }

    void Spawn(GameObject go, float z) {
        Next();
        GameObject spawn = (GameObject)Instantiate(go, new Vector3(transform.position.x, transform.position.y, z), transform.rotation);
        PlatformScript [] ps  = spawn.GetComponentsInChildren<PlatformScript>();
        if (ps.Length == 0) {
            Debug.LogError("Spawned platform does not have a platform script. It is needed to toggle between 2d and 3d");
        } else {
            foreach (PlatformScript p in ps) {
                p.ChangeDimension(is3D);
            } 
        }

        spawn.transform.parent = transform.parent;
    }

    public void ChangeDimensions(bool is3D) {
        this.is3D = is3D;
    }
}
