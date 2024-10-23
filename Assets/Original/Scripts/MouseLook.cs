using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensetive = 100f;

    [SerializeField] private Transform playerBody;

    float xRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }



    private void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;

        float mouseX = Input.GetAxis("Mouse X") * mouseSensetive * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensetive * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);


        playerBody.Rotate(Vector3.up * mouseX);
    }
}
