using UnityEngine;

[ExecuteInEditMode]
public class Tile : MonoBehaviour
{
    public Vector2Int gridPosition;
    public int movementCost = 1;

    private Renderer tileRenderer;

    void Awake()
    {
        tileRenderer = GetComponent<Renderer>();
        UpdateTileColor();
    }

    public void UpdateTileColor()
    {
        if (tileRenderer == null) return;

        if (movementCost == 0)
        {
            tileRenderer.material.color = new Color32(30, 30, 90, 255); // #1E1E33

        }
        else
        {
            switch (movementCost)
            {
                case 1:
                    tileRenderer.material.color = new Color32(30, 30, 150, 255); // #1E1E5D

                    break;
                case 2:
                    tileRenderer.material.color = Color.yellow;
                    break;
                default:
                    tileRenderer.material.color = new Color32(100, 30, 150, 255); // #3F1E5D

                    break;
            }
        }
    }
}
