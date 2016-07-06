using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuOnDeath : MonoBehaviour {

    public IEnumerator Killed()
    {
        Debug.Log("Change scene to main menu");
        //play death animation
        gameObject.GetComponent<PlayerControll>().CanControlCharacter(false);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("MainMenu");
    }
}