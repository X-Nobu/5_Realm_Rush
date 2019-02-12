using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour {

    [SerializeField] Waypoint startwaypoint, endwaypoint;
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    bool isRunning = true;
    Waypoint searchCenter;
    List<Waypoint> path = new List<Waypoint>();

    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    public List<Waypoint> GetPath()
    {
        if (path.Count == 0)
        {
            CalculatePath();
        }

        return path;
        
       
        
    }

    private void CalculatePath()
    {
        LoadBlocks();
        
        BreadthFirstSearch();
        CreatePath();
    }

    private void CreatePath()
    {
        SetAsPath(endwaypoint);

        Waypoint previous = endwaypoint.exploredFrom;
        while (previous != startwaypoint)
        {
            SetAsPath(previous);
            previous = previous.exploredFrom;
        }

        SetAsPath(startwaypoint);
        path.Reverse();
    }

    private void SetAsPath(Waypoint waypoint)
    {
        path.Add(waypoint);
        waypoint.isPlaceable = false;
    }

    private void BreadthFirstSearch()
    {
        queue.Enqueue(startwaypoint);

        while(queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();
          
            searchCenter.isExplored = true;
            HaltIfEndFound();
            ExploreNeighbours();
        }
     
    }

    private void HaltIfEndFound()
    {
        if (searchCenter == endwaypoint)
        {
            print("Searching from end node, therefore stopping"); // remove later
            isRunning = false;
        }
    }

    private void ExploreNeighbours()
    {
        if (!isRunning)
        {
            return;
        }
        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighbourCoordinates = searchCenter.GetGridPos() + direction;
            if (grid.ContainsKey(neighbourCoordinates))
            {
                QueueNewNeighbours(neighbourCoordinates);
            }
       
        }
    }

    private void QueueNewNeighbours(Vector2Int explorationCoordinates)
    {
        Waypoint neighbour = grid[explorationCoordinates];
        if (neighbour.isExplored || queue.Contains(neighbour))
        {

        }
        else
        {
            queue.Enqueue(neighbour);
            neighbour.exploredFrom = searchCenter;
        }
    }



    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            var gridPos = waypoint.GetGridPos();
            bool isOverlapping = grid.ContainsKey(gridPos);
            if (isOverlapping)
            {
                Debug.LogWarning("Overlapping block " + waypoint);
            }
            else
            {
                grid.Add(gridPos, waypoint);
               
            }
            
        }
   
    }

}
