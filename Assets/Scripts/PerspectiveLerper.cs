using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class PerspectiveLerper : MonoBehaviour {

    private Matrix4x4 ortho;
    private Matrix4x4 perspective;

    private float fov;
    private float near;
    private float far;
    private float orthographicSize;

    private float aspect;

    private Camera cam;

    void Start() {
        cam = GetComponent<Camera>();
        fov = cam.fieldOfView;
        near = cam.nearClipPlane;
        far = cam.farClipPlane;
        orthographicSize = cam.orthographicSize;


        aspect = (Screen.width + 0f) / (Screen.height + 0f);

        perspective = cam.projectionMatrix;

        ortho = Matrix4x4.Ortho(-orthographicSize * aspect, orthographicSize * aspect, -orthographicSize, orthographicSize, near, far);
    }

    Matrix4x4 MatrixLerp(Matrix4x4 from, Matrix4x4 to, float time) {
        Matrix4x4 ret = new Matrix4x4();
        for (int i = 0; i < 16; i++)
            ret[i] = Mathf.Lerp(from[i], to[i], time);
        return ret;
    }

    private IEnumerator LerpFromTo(Matrix4x4 src, Matrix4x4 dest, float duration) {
        float startTime = Time.time;
        while (Time.time - startTime < duration) {
            cam.projectionMatrix = MatrixLerp(src, dest, (Time.time - startTime) / duration);
            yield return null;
        }
        cam.projectionMatrix = dest;
    }

    private Coroutine BlendToMatrix(Matrix4x4 targetMatrix, float duration) {
        StopAllCoroutines();
        return StartCoroutine(LerpFromTo(cam.projectionMatrix, targetMatrix, duration));
    }

    public void LerpToOrthographic(float duration) {
        BlendToMatrix(ortho, duration);
    }

    public void LerpToPerspective(float duration) {
        BlendToMatrix(perspective, duration);
    }
}
