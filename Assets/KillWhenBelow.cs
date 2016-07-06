using UnityEngine;
using System.Collections;

public class KillWhenBelow : MonoBehaviour {

    public float KillHeight { get; set; }
    public float ScreamHeight { get; set; } 

	void Update () {
        if (transform.position.y < ScreamHeight)
        {
            //random cgj-screamer
            if (transform.position.y < KillHeight)
            {
                Debug.Log("Player falled to his death");
                gameObject.SendMessage("Killed");
            }
        } 
	}
}
