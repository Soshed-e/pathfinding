using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class BasePathfinder
{
    protected GridManager gridManager;

    public BasePathfinder(GridManager grid)
    {
        gridManager = grid;
    }

    protected List<Tile> RetracePath(Node endNode)
    {
        List<Tile> path = new List<Tile>();
        Node current = endNode;
        while (current != null)
        {
            path.Add(current.tile);
            current = current.parent;
        }
        path.Reverse();
        return path;
    }

    protected int GetHeuristic(Vector2Int a, Vector2Int b)
    {
        int dx = Mathf.Abs(a.x - b.x);
        int dy = Mathf.Abs(a.y - b.y);
        return (dx + dy)*5;
    }

    protected List<Node> GetNeighbors(Node node, List<Unit> units)
    {
        List<Node> neighbors = new List<Node>();
        Vector2Int pos = node.tile.gridPosition;
        Vector2Int[] directions = { Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left };

        foreach (Vector2Int dir in directions)
        {
            Vector2Int neighborPos = pos + dir;
            Tile tile = gridManager.GetTileAtPosition(neighborPos);
            if (tile != null && tile.movementCost > 0)
            {
                if (!units.Any(u => u.gridPosition == neighborPos))
                {
                    neighbors.Add(new Node(tile, null, 0, 0));
                }
            }
        }
        return neighbors;
    }

    public class Node
    {
        public Tile tile;
        public Node parent;
        public int gCost;
        public int hCost;
        public int fCost => gCost + hCost;

        public Node(Tile tile, Node parent, int gCost, int hCost)
        {
            this.tile = tile;
            this.parent = parent;
            this.gCost = gCost;
            this.hCost = hCost;
        }
    }
}
