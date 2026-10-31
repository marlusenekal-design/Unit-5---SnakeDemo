using System;
using UnityEngine;

[RequireComponent(typeof(SnakeBody))]
[RequireComponent(typeof(SnakeMovement))]
public class SnakeEating : MonoBehaviour
{
    public FoodSpawner foodSpawner;

    public event Action OnAteFood;

    private SnakeBody body;
    private SnakeMovement movement;

    void Awake()
    {
        body = GetComponent<SnakeBody>();
        movement = GetComponent<SnakeMovement>();
    }

    void OnEnable()
    {
        movement.OnMoved += CheckFood;
    }

    void OnDisable()
    {
        movement.OnMoved -= CheckFood;
    }

    void CheckFood()
    {
        if (body.HeadPosition == foodSpawner.FoodPosition)
        {
            body.Grow();

            if (OnAteFood != null)
            {
                OnAteFood();
            }
        }
    }
}