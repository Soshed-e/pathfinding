using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AStarPathfinding : BasePathfinder, IPathfindingAlgorithm
{
    public string AlgorithmName => "A*";

    public AStarPathfinding(GridManager grid) : base(grid) { }

    public List<Tile> FindPath(Vector2Int startPos, Vector2Int targetPos, List<Unit> units)
    {
        var openList = new List<Node>();
        var closed = new HashSet<Vector2Int>();

        Node start = new Node(gridManager.GetTileAtPosition(startPos), null, 0, GetHeuristic(startPos, targetPos));
        openList.Add(start);

        while (openList.Count > 0)
        {
            openList.Sort((a, b) => a.fCost.CompareTo(b.fCost)); 
            Node current = openList[0];

            if (current.tile.gridPosition == targetPos)
                return RetracePath(current);

            openList.RemoveAt(0);
            closed.Add(current.tile.gridPosition);

            foreach (var neighbor in GetNeighbors(current, units))
            {
                if (closed.Contains(neighbor.tile.gridPosition)) continue;

                int tentativeG = current.gCost + neighbor.tile.movementCost * 5;

                Node existing = openList.FirstOrDefault(n => n.tile.gridPosition == neighbor.tile.gridPosition);
                if (existing == null || tentativeG < existing.gCost)
                {
                    neighbor.gCost = tentativeG;
                    neighbor.hCost = GetHeuristic(neighbor.tile.gridPosition, targetPos);
                    neighbor.parent = current;

                    if (existing == null)
                        openList.Add(neighbor);
                }
            }
        }
        return null;
    }
}
