using UnityEngine;

public class MinecraftFPSController : MonoBehaviour
{
    public float speed = 6f;
    public float jumpHeight = 1.2f;
    public float gravity = -20f;
    public float mouseSensitivity = 200f;
    public float sprintSpeed = 16f;
    public Transform cam;

    CharacterController controller;
    Vector3 velocity;
    float xRot = 0f;
    bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // --- Mouse Look ---
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        cam.localRotation = Quaternion.Euler(xRot, 0, 0);
        transform.Rotate(Vector3.up * mouseX);

        // --- Ground check ---
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
            velocity.y = -2f; // Stick to ground (like Minecraft)

        // --- Movement (no acceleration, Minecraft-like) ---
        float x = Input.GetAxisRaw("Horizontal");   // Raw = instant stop/start
        float z = Input.GetAxisRaw("Vertical");
        float currentSpeed = speed;
        if (Input.GetKey(KeyCode.LeftShift) && z > 0) // Only forward
        {
            currentSpeed = sprintSpeed;
        }

        // Movement
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move.normalized * currentSpeed * Time.deltaTime);

        // --- Jump ---
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // --- Gravity ---
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}