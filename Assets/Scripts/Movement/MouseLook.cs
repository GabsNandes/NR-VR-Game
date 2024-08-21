using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 1.5f;
    public GameObject camera;
    float xRotation = 0f;
    float yRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") / 100 * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") / 100 * mouseSensitivity;
        xRotation += mouseX;
        yRotation += mouseY;
        yRotation = Mathf.Clamp(yRotation, -90, 90);
        camera.transform.localRotation = Quaternion.Euler(-yRotation, xRotation, 0f);
    }
}