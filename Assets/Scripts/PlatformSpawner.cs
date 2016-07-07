using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlatformSpawner : MonoBehaviour {

    public Transform player;
    public GameObject[] platforms;

    private float step = 14;
    private float initialZ;
    private float deltaZ = 5;

    private float spawnDistance = 30;

    private bool is3D = true;
    private float gap = 2.5f;

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

    void Spawn(GameObject go, float z) {
        // Spawn objects and change the dimension
        GameObject spawn = (GameObject)Instantiate(go, new Vector3(transform.position.x, transform.position.y, z), transform.rotation);
        PlatformScript [] ps  = spawn.GetComponentsInChildren<PlatformScript>();
        if (ps.Length == 0) {
            Debug.LogError("Spawned platform does not have a platform script. It is needed to toggle between 2d and 3d");
        } else {
            foreach (PlatformScript p in ps) {
                p.ChangeDimension(is3D);
            } 
        }

        // Set parent
        spawn.transform.parent = transform.parent;

        // Get the bounds of spawned object
        ObjectMeasurer bounds = spawn.GetComponent<ObjectMeasurer>();
        if (bounds == null) {
            Debug.LogError("Spawned platform need a ObjectMeasurer script in root object to spawn the next platform in correct position");
            return;
        }

        // Place spawned object
        spawn.transform.Translate(new Vector3(bounds.width / 2, 0, 0));

        // Move spawner to the next spawn point
        transform.Translate(new Vector3(bounds.width + gap, 0, 0));
    }

    public void ChangeDimensions(bool is3D) {
        this.is3D = is3D;
    }
}
