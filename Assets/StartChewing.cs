using UnityEngine;
using System.Collections;
using System;

public class StartChewing : MonoBehaviour {

    public delegate void EventHandler();
    public event EventHandler OnMouthShut;
    private bool isInJawZone;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            isInJawZone = true;
            StartCoroutine(closeAndShutJaws());
            GameObject.FindGameObjectWithTag("dragon").GetComponent<Animator>().SetBool("Chew", true);
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            StopAllCoroutines();
            isInJawZone = false;
            GameObject.FindGameObjectWithTag("dragon").GetComponent<Animator>().SetBool("Chew", false);
        }
    }

    private IEnumerator closeAndShutJaws() {
        while(isInJawZone) {
            yield return new WaitForSeconds(1f);
            OnMouthShut();
        }
    }
}
