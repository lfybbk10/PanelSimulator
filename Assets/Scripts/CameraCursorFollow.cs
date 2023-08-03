using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraCursorFollow : MonoBehaviour
{
    private Camera _camera;
    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    private void Update()
    {
        transform.LookAt(_camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _camera.nearClipPlane)), Vector3.up);
    }
}
