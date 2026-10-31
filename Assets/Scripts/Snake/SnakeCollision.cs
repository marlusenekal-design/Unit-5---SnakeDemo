using System;
using UnityEngine;

[RequireComponent(typeof(SnakeBody))]
[RequireComponent(typeof(SnakeMovement))]
public class SnakeCollision : MonoBehaviour
{
    public BoardBounds board;

    public event Action OnDied;

    private SnakeBody body;
    private SnakeMovement movement;

    void Awake()
    {
        body = GetComponent<SnakeBody>();
        movement = GetComponent<SnakeMovement>();
    }

    void OnEnable()
    {
        movement.OnMoved += CheckCollision;
    }

    void OnDisable()
    {
        movement.OnMoved -= CheckCollision;
    }

    void CheckCollision()
    {
        bool hitWall = !board.IsInside(body.HeadPosition);
        bool hitSelf = body.HitsItself();

        if (hitWall || hitSelf)
        {
            if (OnDied != null)
            {
                OnDied();
            }
        }
    }
}