using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

    public void LoadScene(string scene) {
        SceneManager.LoadScene(scene);
    }
}
