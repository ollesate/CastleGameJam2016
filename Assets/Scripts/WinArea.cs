using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WinArea : MonoBehaviour {

    public Transform rotateAround;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player") {
            col.GetComponent<PlayerControll>().CanControlCharacter(false);
            GameObject target = GameObject.Find("DimensionalCamera");
            Camera cam = target.GetComponent<Camera>();
            target.GetComponent<FollowCamera>().enabled = false;

            Time.timeScale = 0.25f;
            StartCoroutine(rotateCam(cam, 3f * Time.timeScale));
            Invoke("LoadNextScene", 4f * Time.timeScale);

            //
        }
            
    }

    IEnumerator rotateCam(Camera cam, float duration) {
        float timeStart = Time.time;
        while (Time.time - timeStart < duration) {
            cam.transform.RotateAround(rotateAround.position, new Vector3(0, 1, 0), -10f * Time.deltaTime / Time.timeScale);
            yield return null;
        }
        Time.timeScale = 1.0f;
    }

    void LoadNextScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        int result;
        bool isNumber = int.TryParse(scene.name, out result);
        Debug.Log(isNumber);
        Debug.Log(result);
        if (isNumber)
        {
            try
            {
                //you win
                SceneManager.LoadScene((result + 1).ToString());
            }
            catch (UnityException e)
            {
                //fallback
                Debug.Log("fallback scene manager");
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
