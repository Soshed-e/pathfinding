using System.Collections.Generic;
using UnityEngine;

public interface IPathfindingAlgorithm
{
    List<Tile> FindPath(Vector2Int startPos, Vector2Int targetPos, List<Unit> units);
    string AlgorithmName { get; }
}
