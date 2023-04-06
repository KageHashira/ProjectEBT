using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensi = 100f;

    public Transform playerBody;

    float RotX = 0f;



    // Start is called before the first frame update
    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensi * Time.deltaTime;
        float mousey = Input.GetAxis("Mouse Y") * mouseSensi * Time.deltaTime;

        RotX -= mousey;
        RotX = Mathf.Clamp(RotX, -90f, 90f);

        transform.localRotation = Quaternion.Euler(RotX, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
