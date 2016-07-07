using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuOnDeath : MonoBehaviour {

    public IEnumerator Killed()
    {
        Debug.Log("Change scene to main menu");
        GetComponent<Animator>().SetBool("IsDead", true);
        gameObject.GetComponent<PlayerControll>().CanControlCharacter(false);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("MainMenu");
    }
}