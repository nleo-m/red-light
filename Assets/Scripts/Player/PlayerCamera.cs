using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    Camera cam;

    public float mouseSensitivity = 100f;
    float mouseX, mouseY, vRotation = 0;
    float minVRotation = -45f;
    float maxVRotation = 75f;

    void Start()
    {
        cam = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        vRotation -= mouseY;
        vRotation = Mathf.Clamp(vRotation, minVRotation, maxVRotation);

        CameraRotation();
    }

    void CameraRotation()
    {
        cam.transform.localRotation = Quaternion.Euler(vRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}
