using UnityEngine;
using System;

[RequireComponent(typeof(SnakeBody))]
public class SnakeMovement : MonoBehaviour
{
   public float moveInterval = 0.15f;

    public event Action OnMoved;

    private SnakeBody body;
    private Vector2Int direction = Vector2Int.right;
    private Vector2Int nextDirection = Vector2Int.right;
    private float moveTimer;
    private bool isMoving;

    private void Awake()
    {
        body = GetComponent<SnakeBody>();
    }

    private void Update()
    {
        if (!isMoving)
        {
            return;
        }

        moveTimer += Time.deltaTime;

        if (moveTimer >= moveInterval)
        {
            moveTimer = 0f;
            Step();
        }
    }

    void Step()
    {
        direction = nextDirection;
        body.Move(direction);

        if (OnMoved != null)
        {
            OnMoved();
        }
    }

    public void SetDirection(Vector2Int newDirection)
    {
        if (newDirection == -direction)
        {
            return;
        }

        nextDirection = newDirection;
    }

    public void StartMoving()
    {
        direction = Vector2Int.right;
        nextDirection = Vector2Int.right;
        moveTimer = 0f;
        isMoving = true;
    }

    public void Stop()
    {
        isMoving = false;
    }
}
