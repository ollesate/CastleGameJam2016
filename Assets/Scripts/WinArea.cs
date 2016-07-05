using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WinArea : MonoBehaviour {

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player")
            Win();
    }

    void Win()
    {
        Scene scene = SceneManager.GetActiveScene();
        int result;
        bool isNumber = int.TryParse(scene.name, out result);

        if (isNumber)
        {
            try
            {
                //you win
                SceneManager.LoadScene(scene.name + 1);
            }
            catch (UnityException e)
            {
                //fallback
                SceneManager.LoadScene("MainMenu");
            }
        }
        else
        {
            //you win but no next level found
            SceneManager.LoadScene("MainMenu");
        }
    }
}
