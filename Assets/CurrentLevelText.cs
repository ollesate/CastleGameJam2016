using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CurrentLevelText : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Text text = GetComponent<Text>();
        text.text = "Level " + SceneManager.GetActiveScene().name;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
