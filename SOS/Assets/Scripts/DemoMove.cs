using UnityEngine;

public class DemoMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 100f;
    public Transform cameraTransform;

    private float mouseX;
    private float mouseY;
    private float xRotation = 0f;

    void Update()
    {
        // Move the player using WASD keys
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical).normalized;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // Rotate the player based on the camera direction
        transform.rotation = Quaternion.Euler(0f, cameraTransform.rotation.eulerAngles.y, 0f);

        // Rotate the camera using mouse input
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
        mouseY = Mathf.Clamp(mouseY, -90f, 90f);

        cameraTransform.rotation = Quaternion.Euler(mouseY, mouseX, 0f);
    }
}
