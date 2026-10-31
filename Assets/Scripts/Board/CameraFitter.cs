using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraFitter : MonoBehaviour
{
    public BoardBounds board;
    public float sidePadding = 0.5f;
    public float verticalPadding = 2.5f;

    void Start()
    {
        FitBoard();
    }

    void FitBoard()
    {
        Camera cam = GetComponent<Camera>();

        float boardWidth = board.halfWidth * 2 + 1;
        float boardHeight = board.halfHeight * 2 + 1;

        float sizeForHeight = (boardHeight + verticalPadding * 2f) / 2f;
        float sizeForWidth = (boardWidth + sidePadding * 2f) / 2f / cam.aspect;

        cam.orthographicSize = Mathf.Max(sizeForHeight, sizeForWidth);
    }
}