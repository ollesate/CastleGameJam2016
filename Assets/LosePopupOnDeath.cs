using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LosePopupOnDeath : MonoBehaviour {

    public GameObject losePopupPrefab;

    private bool hasTriggered;

    public IEnumerator Killed() {
        if (!hasTriggered) { 
            hasTriggered = true;
            Debug.Log("Player was killed. Show popup");
            //play death animation
            GetComponent<Animator>().SetBool("IsDead", true);
            gameObject.GetComponent<PlayerControll>().CanControlCharacter(false);
            yield return new WaitForSeconds(1);
            Instantiate(losePopupPrefab);
        }
    }
}