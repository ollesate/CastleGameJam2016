using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GoToMainMenuOnClickIfFinished : MonoBehaviour {

    private MoveToSequence moveToSequence;
	void Start () {
        moveToSequence = GetComponent<MoveToSequence>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (moveToSequence.isFinished && Input.GetKeyDown(KeyCode.Return)) {
            SceneManager.LoadScene("MainMenu");
        }
	}
}
