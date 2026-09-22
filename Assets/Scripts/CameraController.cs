using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    private Vector2 lookInput;
    private float cameraPitch;
    [SerializeField] private Transform player;
    [SerializeField] private float mouseSensitivity = 0.1f;
    [SerializeField] private float verticalLookLimit = 80f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = lookInput.x * mouseSensitivity;
        float mouseY = lookInput.y * mouseSensitivity;

        // Rotation horizontale du joueur
        player.Rotate(Vector3.up * mouseX);
        
        // Rotation verticale de la caméra
        cameraPitch -= mouseY;
        cameraPitch = Mathf.Clamp(cameraPitch, -verticalLookLimit, verticalLookLimit);
        transform.localRotation = Quaternion.Euler(cameraPitch, 0f, 0f);
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            lookInput = context.ReadValue<Vector2>();
        }
    }
}
