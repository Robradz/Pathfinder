using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();

    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    [SerializeField] Waypoint startWaypoint, endWaypoint;

    bool isRunning = true;
    Waypoint searchCenter;
    private List<Waypoint> path = new List<Waypoint>();

    public List<Waypoint> GetPath()
    {
        if (path.Count == 0)
        {
            LoadBlocks();
            ColorStartAndEnd();
            BreadthFirstSearch();
            CreatePath();
        }
        return path;
    }

    private void CreatePath()
    {
        path.Add(endWaypoint);

        Waypoint previous = endWaypoint.exploredFrom;

        while (previous != startWaypoint)
        {
            path.Add(previous);
            previous = previous.exploredFrom;
        }

        path.Add(startWaypoint);
        path.Reverse();
    }

    private void BreadthFirstSearch()
    {
        queue.Enqueue(startWaypoint);

        while(queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();
            searchCenter.isExplored = true;

            if (searchCenter.name == endWaypoint.name)
            {
                isRunning = false;
            }

            ExploreNeighbors();
        }
    }

    private void ExploreNeighbors()
    {
        if (!isRunning) { return; }

        foreach (Vector2Int direction in directions)
        {
            Vector2Int explorationCoordinates = searchCenter.GetGridPos() + direction;
            if(grid.ContainsKey(explorationCoordinates))
            {
                QueueNeighbors(explorationCoordinates);
            }
        }
    }

    private void QueueNeighbors(Vector2Int ExplorationCoordinates)
    {
        Waypoint neighbor = grid[ExplorationCoordinates];
        if (!neighbor.isExplored && !queue.Contains(neighbor))
        {
            queue.Enqueue(neighbor);
            neighbor.exploredFrom = searchCenter;
        }
    }

    private void LoadBlocks()
    {
        Waypoint[] waypoints = FindObjectsOfType<Waypoint>(); 
        foreach (Waypoint waypoint in waypoints)
        {
            bool overlap = grid.ContainsKey(waypoint.GetGridPos());
            // add to dictionary
            if (overlap)
            {
                Debug.LogWarning("Overlapping block at " + waypoint);
            }
            else
            {
                grid.Add(waypoint.GetGridPos(), waypoint);
            }
        }
    }

    private void ColorStartAndEnd()
    {
        startWaypoint.SetTopColor(Color.green);
        endWaypoint.SetTopColor(Color.red);
    }
}
