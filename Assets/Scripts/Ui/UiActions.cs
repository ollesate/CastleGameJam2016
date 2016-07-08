using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UiActions : MonoBehaviour {


    public void StartGame()
    {
        GameObject.Find("CutScene").GetComponent<MoveForward>().enabled = true;
        Invoke("LoadFirstLevel", 4);
    }

    public void StartEndless() {
        GameObject.Find("CutScene").GetComponent<MoveForward>().enabled = true;
        Invoke("LoadEndlessLevel", 4);
    }

    private void LoadFirstLevel()
    {
        SceneManager.LoadScene("2");
    }

	public void StartTutorial()
	{
		GameObject.Find("CutScene").GetComponent<MoveForward>().enabled = true;
		Invoke("LoadTutorialLevel", 4);
	}

	private void LoadTutorialLevel()
	{
		SceneManager.LoadScene("1");
	}

    private void LoadEndlessLevel() {
        SceneManager.LoadScene("endless");

    }
}
