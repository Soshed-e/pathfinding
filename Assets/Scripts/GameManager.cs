using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Юниты")]
    public Player player;

    [Header("Визуализация")]
    public Color aStarColor = Color.blue;
    public Color dijkstraColor = Color.yellow;
    public Color bfsColor = Color.red;
    public Color gbfsColor = Color.magenta;

    private GridManager gridManager;
    private MultiPathfindingManager multiManager;
    private List<LineRenderer> lineRenderers = new List<LineRenderer>();
    private int currentVisibleLineIndex = -1; // Какая линия активна
    private bool showAllLines = false; // Показываем ли все линии



    [Header("UI")]
    public PathfindingUIController uiController;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        gridManager = FindAnyObjectByType<GridManager>();
        multiManager = new MultiPathfindingManager(gridManager);

        CreateLineRenderers();
    }

    void Update()
    {
        HandlePlayerClick();

        if (CameraController.isTopDown && Input.GetKeyDown(KeyCode.R))
        {
            ShowNextLine();
        }
    }



    void HandlePlayerClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hitInfo))
            {
                Tile clickedTile = hitInfo.collider.GetComponent<Tile>();
                if (clickedTile != null)
                {
                    Vector2Int target = clickedTile.gridPosition;
                    StartCoroutine(RunAllPathfindings(player.gridPosition, target));
                }
            }
        }
    }

    System.Collections.IEnumerator RunAllPathfindings(Vector2Int start, Vector2Int target)
    {
        ClearAllPaths();

        List<Unit> units = new List<Unit> { player };
        var results = multiManager.RunAllAlgorithms(start, target, units);

        for (int i = 0; i < results.Count; i++)
        {
            if (results[i].Path != null)
                DrawPath(results[i].Path, i);
        }

        var bestResult = results
            .Where(r => r.Path != null && r.Path.Count > 0)
            .OrderBy(r => r.TotalCost)
            .FirstOrDefault();

        if (bestResult != null)
        {
            Tile destination = bestResult.Path[bestResult.Path.Count - 1];
            player.MoveTo(destination.gridPosition);
        }

        foreach (var result in results)
        {
            Debug.Log($"[{result.AlgorithmName}] Cost: {result.TotalCost}, Length: {result.PathLength}, Time: {result.DurationMs} ms");
        }

        if (uiController != null)
            uiController.UpdateUI(results);

        yield return null;
    }

    void CreateLineRenderers()
    {
        Color[] colors = { aStarColor, dijkstraColor, bfsColor, gbfsColor };

        for (int i = 0; i < 4; i++)
        {
            GameObject lineObj = new GameObject("LineRenderer_" + i);
            lineObj.transform.parent = this.transform;
            LineRenderer lr = lineObj.AddComponent<LineRenderer>();
            lr.startWidth = 0.2f;
            lr.endWidth = 0.2f;
            lr.material = new Material(Shader.Find("Sprites/Default"));
            lr.startColor = colors[i];
            lr.endColor = colors[i];
            lr.positionCount = 0;
            lineRenderers.Add(lr);
        }
    }

    void DrawPath(List<Tile> path, int index)
    {
        if (index >= lineRenderers.Count || path == null) return;

        LineRenderer lr = lineRenderers[index];
        lr.positionCount = path.Count;

        float verticalOffset = 0.5f + ((index + 1) * 0.15f);

        for (int i = 0; i < path.Count; i++)
        {
            lr.SetPosition(i, path[i].transform.position + Vector3.up * verticalOffset);
        }
    }

    void ShowNextLine()
    {
        if (showAllLines)
        {
            currentVisibleLineIndex = 0;
            showAllLines = false;
        }
        else
        {
            currentVisibleLineIndex++;
        }

        if (currentVisibleLineIndex >= lineRenderers.Count)
        {
            showAllLines = true;
            currentVisibleLineIndex = -1;
        }

        for (int i = 0; i < lineRenderers.Count; i++)
        {
            if (lineRenderers[i] != null)
            {
                if (showAllLines)
                {
                    lineRenderers[i].enabled = true;
                }
                else
                {
                    lineRenderers[i].enabled = (i == currentVisibleLineIndex);
                }
            }
        }
    }


    public void ClearAllPaths()
    {
        foreach (var lr in lineRenderers)
        {
            lr.positionCount = 0;
        }
    }
}

