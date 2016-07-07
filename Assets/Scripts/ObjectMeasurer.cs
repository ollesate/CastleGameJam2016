using UnityEngine;
using System.Collections;

public class ObjectMeasurer : MonoBehaviour {
    public float width;

	void Awake () {
        float startX = float.MaxValue;
        float endX = float.MinValue;

        foreach (Renderer r in GetComponentsInChildren<Renderer>()) {
            if (endX < r.bounds.max.x) {
                endX = r.bounds.max.x;
            }

            if (startX > r.bounds.min.x) {
                startX = r.bounds.min.x;
            }
        }
        width = endX - startX;
	}
}
