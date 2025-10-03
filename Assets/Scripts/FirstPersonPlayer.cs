using UnityEngine;

public class FirstPersonPlayer : MonoBehaviour
{
    // Reference to the Camera
    public GameObject cameraObject;

    // Sensitivity for Camera Rotation when looking
    private int mouseSensitivity;

    // Current amount camera is rotated on x-axis
    private float xCameraRotation = 0f;

    // Speed player moves with thir input (non-normalized)
    private int movementSpeed;

    // Player Rigidbody
    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Init Rigidbody to Player's
        rb = GetComponent<Rigidbody>();

        // Lock cursor to center of the screen
        Cursor.lockState = CursorLockMode.Locked;

        // Loads sensitivity from GameManager
        mouseSensitivity = GameManager.instance.playerMouseSensitivity;

        // Loads movementSpeed from GameManager
        movementSpeed = GameManager.instance.playerMovementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // Camera Rotation Code
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        /// X is left-right axis, so upwards mouse movement rotates camera on x-axis
        xCameraRotation -= mouseY;
        // Prevents rotation beyond 90 degrees or less than -90 degrees
        xCameraRotation = Mathf.Clamp(xCameraRotation, -90f, 90f);

        // Apply rotations
        cameraObject.transform.localRotation = Quaternion.Euler(xCameraRotation, 0f, 0f); // X-axis rotation by assigning **Camera's** rotation
        transform.Rotate(Vector3.up * mouseX); // Y-axis rotation by rotating the **Player**, whom this script is attached to


        // Movement Code (using WASD)
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(new Vector3(0, 0, 1) * movementSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(new Vector3(0, 0, -1) * movementSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(new Vector3(-1, 0, 0) * movementSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(new Vector3(1, 0, 0) * movementSpeed);
        }
    }
}
