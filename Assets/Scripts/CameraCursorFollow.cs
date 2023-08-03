using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraCursorFollow : MonoBehaviour
{
    private Camera _camera;

    private float speedH = 10f;
    private float speedV = 10f;

    private float yaw = 0;
    private float pitch = 0;
    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    private void Update()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");
        
        yaw = Mathf.Clamp(yaw, -90f, 90f);
        pitch = Mathf.Clamp(pitch, -60f, 90f);
        
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
}
