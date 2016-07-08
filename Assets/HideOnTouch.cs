using UnityEngine;
using System.Collections;

public class HideOnTouch : MonoBehaviour {

    void OnTriggerEnter(Collider collider) {
        Debug.Log("Enter");
        SkinnedMeshRenderer [] renderers =  collider.gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
        foreach (SkinnedMeshRenderer r in renderers) {
            r.enabled = false;
        }
    }
}
