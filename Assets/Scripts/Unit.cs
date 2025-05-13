using UnityEngine;

public abstract class Unit : MonoBehaviour
{

    public Vector2Int gridPosition;

    protected GridManager gridManager;

    protected virtual void Start()
    {
        gridManager = FindAnyObjectByType<GridManager>();
        if (gridManager != null)
        {
            Tile tile = gridManager.GetTileAtPosition(gridPosition);
            if (tile != null)
            {
                transform.position = tile.transform.position + Vector3.up * 1.5f;
            }
        }
    }

    public void MoveTo(Vector2Int targetPos)
    {
        gridPosition = targetPos;

        if (gridManager == null)
            gridManager = FindAnyObjectByType<GridManager>();

        Tile targetTile = gridManager.GetTileAtPosition(targetPos);
        if (targetTile != null)
        {
            transform.position = targetTile.transform.position + Vector3.up * 1.5f;
        }
    }

}