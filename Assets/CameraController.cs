using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 10f;
    public Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        Vector3 Rotation = new Vector3(-mouseY, mouseX, 0);

        transform.Rotate(Rotation);
        transform.eulerAngles += Rotation;

        //Cancel out Z rotation so camera does not tilt
        transform.Rotate(0,0,-transform.eulerAngles.z);

        transform.position = playerTransform.position;
        playerTransform.Rotate(Vector3.up * mouseX);
    }
}
