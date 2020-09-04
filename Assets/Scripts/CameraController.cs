using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    private float zoom = 10f;
    public float zoomSpeed = 4f;
    public float zoomMin = 5f;
    public float zoomMax = 15f;
    public float pitch = 2f;

    public float yawSpeed = 100f;
    public float currentYaw = 0f;

    void Update() {
        zoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        zoom = Mathf.Clamp(zoom, zoomMin, zoomMax);

        currentYaw -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
    }

    void LateUpdate() {
        transform.position = target.position - offset * zoom;
        transform.LookAt(target.position + Vector3.up * pitch);

        transform.RotateAround(target.position, Vector3.up, currentYaw);
    }
}
