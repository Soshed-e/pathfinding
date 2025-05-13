using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class PathfindingResult
{
    public string AlgorithmName;
    public List<Tile> Path;
    public float DurationMs;
    public int TotalCost;
    public int PathLength; 
}

public class MultiPathfindingManager
{
    private List<IPathfindingAlgorithm> algorithms;

    public MultiPathfindingManager(GridManager grid)
    {
        algorithms = new List<IPathfindingAlgorithm>
        {
            new AStarPathfinding(grid),
            new DijkstraPathfinding(grid),
            new BFSPathfinding(grid),
            new GBFSPathfinding(grid)
        };
    }

    public List<PathfindingResult> RunAllAlgorithms(Vector2Int start, Vector2Int end, List<Unit> units)
    {
        List<PathfindingResult> results = new List<PathfindingResult>();

        foreach (var algorithm in algorithms)
        {
            Stopwatch sw = Stopwatch.StartNew();
            var path = algorithm.FindPath(start, end, units);
            sw.Stop();

            int totalCost = 0;
            int pathLength = 0;

            if (path != null)
            {
                pathLength = path.Count;
                foreach (var tile in path)
                    totalCost += tile.movementCost;
            }

            results.Add(new PathfindingResult
            {
                AlgorithmName = algorithm.AlgorithmName,
                Path = path,
                DurationMs = (float)sw.Elapsed.TotalMilliseconds,
                TotalCost = totalCost,
                PathLength = pathLength
            });
        }

        return results;
    }

}
