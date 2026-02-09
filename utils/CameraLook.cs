using UnityEngine;
using UnityEngine.InputSystem;

public class CameraLook : MonoBehaviour
{
    public float sensitivity = 1.0f;

    private PlayInput inputActions;
    private Vector2 lookInput;

    private float pitch = 0f;
    private float yaw = 0f;

    private void Start()
    {
        inputActions = new PlayInput();
        inputActions.PlayerController.Look.performed += Look;
        inputActions.PlayerController.Look.canceled += Look;
        inputActions.Enable();
    }

    public void Look(InputAction.CallbackContext context) {
        lookInput = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        yaw += lookInput.x * sensitivity;
        pitch -= lookInput.y * sensitivity;

        pitch = Mathf.Clamp(pitch, -80f, 80f);

        transform.rotation = Quaternion.Euler(pitch, yaw, 0);
    }
}