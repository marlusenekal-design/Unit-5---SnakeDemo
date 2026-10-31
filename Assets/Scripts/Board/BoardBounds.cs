using UnityEngine;

public class BoardBounds : MonoBehaviour
{
    public int halfWidth = 8;
    public int halfHeight = 15;

    public bool IsInside(Vector2Int position)
    {
        return Mathf.Abs(position.x) <= halfWidth && Mathf.Abs(position.y) <= halfHeight;
    }
}
