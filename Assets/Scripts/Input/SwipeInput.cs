using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(SnakeMovement))]
public class SwipeInput : MonoBehaviour
{
    public float minSwipeDistance = 50f;

    private SnakeMovement movement;
    private Vector2 startPos;
    private bool swiping;

    void Awake()
    {
        movement = GetComponent<SnakeMovement>();
    }

    void Update()
    {
        if (Pointer.current == null)
        {
            return;
        }

        if (Pointer.current.press.wasPressedThisFrame)
        {
            startPos = Pointer.current.position.ReadValue();
            swiping = true;
        }

        if (Pointer.current.press.wasReleasedThisFrame)
        {
            swiping = false;
        }

        if (!swiping)
        {
            return;
        }

        Vector2 delta = Pointer.current.position.ReadValue() - startPos;

        if (delta.magnitude < minSwipeDistance)
        {
            return;
        }

        if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
        {
            movement.SetDirection(delta.x > 0 ? Vector2Int.right : Vector2Int.left);
        }
        else
        {
            movement.SetDirection(delta.y > 0 ? Vector2Int.up : Vector2Int.down);
        }

        swiping = false;
    }
}