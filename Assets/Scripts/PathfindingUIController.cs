using System;
using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class PathfindingUIController : MonoBehaviour
{
    [System.Serializable]
    public class AlgorithmUI
    {
        public string algorithmName;
        public TMP_Text nameText;
        public TMP_Text costText;
        public TMP_Text timeText;
        public TMP_Text lengthText; 
    }

    public List<AlgorithmUI> algorithmUIs;

    public void UpdateUI(List<PathfindingResult> results)
    {
        foreach (var result in results)
        {
            Debug.Log($"[UI DEBUG] Update UI for: {result.AlgorithmName}");

            AlgorithmUI ui = algorithmUIs.Find(a => a.algorithmName == result.AlgorithmName);

            if (ui == null)
            {
                Debug.LogWarning($"[UI WARNING] Cant find UI-block: {result.AlgorithmName}");
                continue;
            }

            ui.nameText.text = result.AlgorithmName;
            ui.costText.text = Convert.ToString(result.TotalCost);
            ui.lengthText.text = Convert.ToString(result.PathLength);
            ui.timeText.text = Convert.ToString(result.DurationMs);
        }
    }
    public void ClearUI()
    {
        Debug.Log("[UI] Clearing algorithm UI");
        foreach (var ui in algorithmUIs)
        {
            ui.nameText.text = "-";
            ui.costText.text = "-";
            ui.lengthText.text = "-";
            ui.timeText.text = "-";
        }
    }

}
