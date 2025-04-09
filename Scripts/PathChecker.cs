
using UnityEngine;

public class PathChecker : MonoBehaviour
{
    public PuzzleManager puzzleManager;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space pressed");
            if (CheckRotationMatch())
            {
                puzzleManager.CompleteLevel();
            }
        }
    }

    bool CheckRotationMatch()
    {
        GridTile[] tiles = puzzleManager.levels[puzzleManager.currentLevel].GetComponentsInChildren<GridTile>();

        foreach (GridTile tile in tiles)
        {
            if (tile.type == GridTile.TileType.Blank || tile.ignoreRotation)
                continue;

            int actual = tile.GetRotationDegrees();

            if (tile.validRotations != null && tile.validRotations.Length > 0)
            {
                bool match = false;
                foreach (int r in tile.validRotations)
                {
                    int normalized = ((r % 360) + 360) % 360;
                    if (actual == normalized)
                    {
                        match = true;
                        break;
                    }
                }

                if (!match)
                {
                    Debug.Log($"Tile at {tile.transform.position} is incorrect. Got {actual}");
                    return false;
                }
            }
            else
            {
                int expected = ((tile.expectedRotation % 360) + 360) % 360;
                if (actual != expected)
                {
                    Debug.Log($"Tile at {tile.transform.position} is incorrect. Expected {expected}, got {actual}");
                    return false;
                }
            }
        }

        Debug.Log("✔ All tiles rotated correctly!");
        return true;
    }
}
