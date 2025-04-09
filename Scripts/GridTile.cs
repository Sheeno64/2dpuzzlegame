
using UnityEngine;

public class GridTile : MonoBehaviour
{
    public enum TileType { Start, Corner, End, TJunction, Blank }
    public TileType type;

    public int expectedRotation;
    public int[] validRotations;
    public bool ignoreRotation;

    void OnMouseDown()
    {
        RotateTile();
    }

    void RotateTile()
    {
        transform.Rotate(0f, 0f, -90f);
    }

    public int GetRotationDegrees()
    {
        float z = transform.eulerAngles.z;
        return Mathf.RoundToInt(z) % 360;
    }
}
