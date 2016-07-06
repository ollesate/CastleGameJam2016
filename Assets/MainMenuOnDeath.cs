using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuOnDeath : MonoBehaviour {

    public void Killed() {
        Debug.Log("Change scene to main menu");
        SceneManager.LoadScene("MainMenu");
    }
}
