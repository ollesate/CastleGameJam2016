using UnityEngine;
using System.Collections;

public class KillWhenBelow : MonoBehaviour {

    private float killHeight = -5;
    private float screamHeight = 0;

    private bool soundNotPlayed = true;
    private bool killNotSent = true;
    AudioSource scream;

    void Start()
    {
        scream = GetComponents<AudioSource>()[0];
    }

	void Update () {
        if (killNotSent)
        { 
            if (transform.position.y < screamHeight)
            {
                if (soundNotPlayed)
                {
                    scream.Play();
                    soundNotPlayed = false;
                }
                if (transform.position.y < killHeight)
                {
                    scream.Stop();
                    killNotSent = false;
                    Debug.Log("Player falled to his death");
                    gameObject.SendMessage("Killed");
                }
            }
        }
	}
}
