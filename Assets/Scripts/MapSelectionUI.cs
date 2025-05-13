using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class MapSelectionUI : MonoBehaviour
{
    [System.Serializable]
    public class MapOption
    {
        public GameObject mapPrefab;
        public Vector2Int playerSpawnPosition;
    }

    [Header("List of map options (prefab + spawn position)")]
    public List<MapOption> mapOptions;

    [Header("Button prefab")]
    public Button buttonPrefab;

    [Header("Button container")]
    public Transform buttonContainer;

    [Header("References")]
    public GridManager gridManager;
    public Player player;
    public GameManager gameManager; // Needed to clear paths
    public PathfindingUIController uiController; // Needed to clear UI info

    private GameObject currentMapInstance;

    void Start()
    {
        foreach (MapOption option in mapOptions)
        {
            Button btn = Instantiate(buttonPrefab, buttonContainer);
            btn.GetComponentInChildren<TMP_Text>().text = option.mapPrefab.name;
            btn.onClick.AddListener(() => LoadMap(option));
        }
    }

    void LoadMap(MapOption option)
    {
        if (currentMapInstance != null)
        {
            Destroy(currentMapInstance);
        }

        if (gameManager != null)
        {
            gameManager.ClearAllPaths();
        }

        if (uiController != null)
        {
            uiController.ClearUI();
        }

        currentMapInstance = Instantiate(option.mapPrefab);
        gridManager.SetGridPrefab(currentMapInstance);

        if (player != null)
        {
            player.MoveTo(option.playerSpawnPosition);
        }
    }

}
