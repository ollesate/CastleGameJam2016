using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuOnDeath : MonoBehaviour {

    public IEnumerator Killed()
    {
        Debug.Log("Change scene to main menu");
        //play death animation
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("MainMenu");
    }
}
