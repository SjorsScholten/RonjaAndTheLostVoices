using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {
    public bool lockCursor;
    public Transform target;
    public float offset = 2;
    public float mouseSensitivity = 10;
    public Vector2 pitchClamp = new Vector2(-40, 85);

    public float rotationSmoothTime = 0.12f;
    private Vector3 rotationSmoothVelocity;
    private Vector3 currentRotation;

    private float yaw;
    private float pitch;

    private void Start() {
        if (lockCursor) {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    private void LateUpdate() {
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, pitchClamp.x, pitchClamp.y);

        currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);

        transform.eulerAngles = currentRotation;
        transform.position = target.position - transform.forward * offset;
    }
}
