using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(SnakeMovement))]
public class KeyboardInput : MonoBehaviour
{
    private SnakeMovement movement;

    void Awake()
    {
        movement = GetComponent<SnakeMovement>();
    }

    void Update()
    {
        if (Keyboard.current == null)
        {
            return;
        }

        if (Keyboard.current.upArrowKey.wasPressedThisFrame) movement.SetDirection(Vector2Int.up);
        if (Keyboard.current.downArrowKey.wasPressedThisFrame) movement.SetDirection(Vector2Int.down);
        if (Keyboard.current.leftArrowKey.wasPressedThisFrame) movement.SetDirection(Vector2Int.left);
        if (Keyboard.current.rightArrowKey.wasPressedThisFrame) movement.SetDirection(Vector2Int.right);
    }
}