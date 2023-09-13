using UnityEngine;

public class CarController : MonoBehaviour
{
    public float moveSpeed = 5.0f;   // Speed of camera movement.
    public float rotationSpeed = 2.0f; // Speed of camera rotation.

    void Update()
    {
        // Camera Movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

      
        float moveHorizontal = Input.GetKey(KeyCode.L) ? 1 : Input.GetKey(KeyCode.J) ? -1 : 0;
        float moveVertical = Input.GetKey(KeyCode.I) ? 1 : Input.GetKey(KeyCode.K) ? -1 : 0;

        Vector3 moveDirection = new Vector3(moveHorizontal, 0, moveVertical);
        moveDirection.Normalize();

        if (moveDirection != Vector3.zero)
        {
            // Translate camera based on input
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        }

        // Camera Rotation
        float mouseX = Input.GetAxis("Mouse X");
        // float mouseY = Input.GetAxis("Mouse Y");

        // Rotate the camera based on mouse input (optional)
        transform.Rotate(Vector3.up * mouseX * rotationSpeed);
        // transform.Rotate(Vector3.left * mouseY * rotationSpeed);
    }
}