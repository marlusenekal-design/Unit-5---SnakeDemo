using System.Collections.Generic;
using UnityEngine;

public class SnakeBody : MonoBehaviour
{
    public Transform segmentPrefab;
    public int startSize = 3;

    private List<Transform> segments = new List<Transform>();

    public Vector2Int HeadPosition
    {
        get { return Vector2Int.RoundToInt(transform.position); }
    }

    public void Move(Vector2Int direction)
    {
        for (int i = segments.Count - 1; i > 0; i--)
        {
            segments[i].position = segments[i - 1].position;
        }

        transform.position += new Vector3(direction.x, direction.y, 0f);
    }

    public void Grow()
    {
        Transform newSegment = Instantiate(segmentPrefab);
        newSegment.position = segments[segments.Count - 1].position;
        segments.Add(newSegment);
    }

    public bool HitsItself()
    {
        for (int i = 1; i < segments.Count; i++)
        {
            if (Vector2Int.RoundToInt(segments[i].position) == HeadPosition)
            {
                return true;
            }
        }

        return false;
    }

    public bool Occupies(Vector2Int position)
    {
        for (int i = 0; i < segments.Count; i++)
        {
            if (Vector2Int.RoundToInt(segments[i].position) == position)
            {
                return true;
            }
        }

        return false;
    }

    public void ResetBody()
    {
        for (int i = 1; i < segments.Count; i++)
        {
            Destroy(segments[i].gameObject);
        }

        segments.Clear();
        segments.Add(transform);

        transform.position = Vector3.zero;

        for (int i = 1; i < startSize; i++)
        {
            Transform newSegment = Instantiate(segmentPrefab);
            newSegment.position = new Vector3(-i, 0f, 0f);
            segments.Add(newSegment);
        }
    }
}