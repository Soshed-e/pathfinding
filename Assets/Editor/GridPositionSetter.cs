using UnityEngine;
using UnityEditor;

public class GridPositionSetter : MonoBehaviour
{
    [MenuItem("Tools/Set Grid Positions")]
    public static void SetGridPositions()
    {
        float step = 1.1f;

        Tile[] tiles = Object.FindObjectsByType<Tile>(FindObjectsSortMode.None);

        foreach (Tile tile in tiles)
        {
            Vector3 pos = tile.transform.position;

            int x = Mathf.RoundToInt(pos.x / step);
            int y = Mathf.RoundToInt(pos.z / step); // Z если ты в 3D, Y если 2D

            tile.gridPosition = new Vector2Int(x, y);
            EditorUtility.SetDirty(tile);
        }

        Debug.Log("? Grid Position обновлены для всех тайлов!");
    }
}
