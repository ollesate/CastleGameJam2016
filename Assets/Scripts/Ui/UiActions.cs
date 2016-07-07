using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UiActions : MonoBehaviour {


    public void StartGame()
    {
        GameObject.Find("CutScene").GetComponent<MoveForward>().enabled = true;
        Invoke("LoadFirstLevel", 4);
    }

    private void LoadFirstLevel()
    {
        SceneManager.LoadScene("1");
    }
}
