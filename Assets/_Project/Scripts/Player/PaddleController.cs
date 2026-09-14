using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleController : MonoBehaviour
{
    [SerializeField] private float moveInput;

    private void Update()
    {
        moveInput = 0f;

        if (Keyboard.current == null)
        {
            return;
        }

        if (Keyboard.current.leftArrowKey.isPressed ||
            Keyboard.current.aKey.isPressed)
        {
            moveInput = -1f;
        }

        if (Keyboard.current.rightArrowKey.isPressed ||
            Keyboard.current.dKey.isPressed)
        {
            moveInput = 1f;
        }
    }
}