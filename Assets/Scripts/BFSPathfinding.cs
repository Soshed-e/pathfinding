using System.Collections.Generic;
using UnityEngine;

public class BFSPathfinding : BasePathfinder, IPathfindingAlgorithm
{
    public string AlgorithmName => "BFS";

    public BFSPathfinding(GridManager grid) : base(grid) { }

    public List<Tile> FindPath(Vector2Int startPos, Vector2Int targetPos, List<Unit> units)
    {
        var queue = new Queue<Node>();
        var visited = new HashSet<Vector2Int>();

        Node start = new Node(gridManager.GetTileAtPosition(startPos), null, 0, 0);
        queue.Enqueue(start);
        visited.Add(startPos);

        while (queue.Count > 0)
        {
            Node current = queue.Dequeue();

            if (current.tile.gridPosition == targetPos)
                return RetracePath(current);

            foreach (var neighbor in GetNeighbors(current, units))
            {
                if (visited.Contains(neighbor.tile.gridPosition)) continue;

                neighbor.parent = current;
                queue.Enqueue(neighbor);
                visited.Add(neighbor.tile.gridPosition);
            }
        }

        return null;
    }
}
