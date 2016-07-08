using UnityEngine;
using System.Collections;

public class StartChewing : MonoBehaviour {

    void OnTriggerEnter(Collider col)
    {
        
        if (col.tag == "Player")
        {
            Debug.Log("player enter");
            GameObject.FindGameObjectWithTag("dragon").GetComponent<Animator>().SetBool("Chew", true);
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            Debug.Log("player leave");
            GameObject.FindGameObjectWithTag("dragon").GetComponent<Animator>().SetBool("Chew", false);
        }
    }
}
