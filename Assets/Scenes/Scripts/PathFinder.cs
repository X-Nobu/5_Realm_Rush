using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour {

    [SerializeField] Waypoint startwaypoint, endwaypoint;
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    bool isRunning = true;

    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

	void Start ()
    {
        LoadBlocks();
        ColorStartAndEnd();
        PathFind();
      //  ExploreNeighbours();
    }

    private void PathFind()
    {
        queue.Enqueue(startwaypoint);

        while(queue.Count > 0)
        {
            var searchCenter = queue.Dequeue();
            print(searchCenter); // remove later
            HaltIfEndFound(searchCenter);
        }
        print("finshed path finding?"); // rmeov elater
    }

    private void HaltIfEndFound(Waypoint searchCenter)
    {
        if (searchCenter == endwaypoint)
        {
            print("Searching from end node"); // remove later
            isRunning = false;
        }
    }

    private void ExploreNeighbours()
    {
        foreach (Vector2Int direction in directions)
        {
            Vector2Int explorationCoordinates = startwaypoint.GetGridPos() + direction;
            try
            {
                grid[explorationCoordinates].SetTopColor(Color.blue);
            }
            catch
            {

            }
        }
    }

    private  void ColorStartAndEnd()
    {
        startwaypoint.SetTopColor(Color.green);
        endwaypoint.SetTopColor(Color.red);
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

    // Update is called once per frame
    void Update () {
		
	}
}
