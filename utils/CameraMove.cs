using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMove : MonoBehaviour
{
    private Vector2 moveInput;
    private PlayInput inputActions;

    void Start()
    {
        inputActions = new PlayInput();
        inputActions.PlayerController.Move.performed += Move;
        inputActions.PlayerController.Move.canceled += Move;
        inputActions.Enable();
    }

    public void Move(InputAction.CallbackContext context) {
        moveInput = context.ReadValue<Vector2>();
    }

    void Update()
    {
        Vector3 move = transform.forward * moveInput.y + transform.right * moveInput.x;
        transform.position += move * Time.deltaTime * 5f;
    }
}
