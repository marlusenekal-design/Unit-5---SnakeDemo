using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public Transform food;
    public BoardBounds board;
    public SnakeBody snakeBody;

    public Vector2Int FoodPosition { get; private set; }

    public void Spawn()
    {
        List<Vector2Int> freeCells = new List<Vector2Int>();

        for (int x = -board.halfWidth; x <= board.halfWidth; x++)
        {
            for (int y = -board.halfHeight; y <= board.halfHeight; y++)
            {
                Vector2Int cell = new Vector2Int(x, y);

                if (!snakeBody.Occupies(cell))
                {
                    freeCells.Add(cell);
                }
            }
        }

        if (freeCells.Count == 0)
        {
            return;
        }

        FoodPosition = freeCells[Random.Range(0, freeCells.Count)];
        food.position = new Vector3(FoodPosition.x, FoodPosition.y, 0f);
    }
}