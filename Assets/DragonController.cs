using UnityEngine;
using System.Collections;

public class DragonController : MonoBehaviour {

    private bool isInsideKillZone;
    private StartChewing chewingController;
    private GameObject player;
    private bool isPlayerDead;
    private MoveTowards moveTowards;
    public Transform secondaryTarget;
	// Use this for initialization
	void Start () {
        chewingController = GetComponentInChildren<StartChewing>();
        chewingController.OnMouthShut += OnJawsShut;
        moveTowards = GetComponent<MoveTowards>();
	}

    void OnTriggerEnter(Collider col) {

        if (col.tag == "Player") {
            player = col.gameObject;
        }
    }

    void OnTriggerExit(Collider col) {
        if (col.tag == "Player") {
            player = null;
        }
    }

    void OnJawsShut() {
        if (player != null && !isPlayerDead) {
            killPlayer();
        }
    }

    void killPlayer() {
        SkinnedMeshRenderer[] renderers = player.gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
        foreach (SkinnedMeshRenderer r in renderers) {
            r.enabled = false;
        }
        player.SendMessage("Killed");
        isPlayerDead = true;
        GameObject.FindGameObjectWithTag("dragon").GetComponent<Animator>().SetBool("Chew", false);
        Invoke("moveTowardsSecondaryTarget", 1f);
    }

    void moveTowardsSecondaryTarget() {
        moveTowards.target = secondaryTarget;
    }

    // Update is called once per frame
    void Update () {
	
	}
}
