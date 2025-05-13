using UnityEngine;
using System.Collections.Generic;

public class GridManager : MonoBehaviour
{
    private Dictionary<Vector2Int, Tile> tileDictionary = new Dictionary<Vector2Int, Tile>();
    private GameObject currentGrid;

    public void SetGridPrefab(GameObject gridPrefab)
    {
        if (currentGrid != null)
        {
            Destroy(currentGrid);
        }

        tileDictionary.Clear();

        currentGrid = Instantiate(gridPrefab, Vector3.zero, Quaternion.identity, transform);
        Tile[] tiles = currentGrid.GetComponentsInChildren<Tile>();

        foreach (Tile tile in tiles)
        {
            Vector2Int pos = tile.gridPosition;
            tileDictionary[pos] = tile;
            tile.UpdateTileColor();
        }
    }

    public Tile GetTileAtPosition(Vector2Int pos)
    {
        return tileDictionary.TryGetValue(pos, out Tile tile) ? tile : null;
    }
}
