using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuOnDeath : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnDestroy() {
        Debug.Log("Change scene to main menu");
        SceneManager.LoadScene("MainMenu");
    }
}
