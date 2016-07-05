using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UiActions : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartGame() {
        Debug.Log("Start game");
        SceneManager.LoadScene("scene");
    }
}
