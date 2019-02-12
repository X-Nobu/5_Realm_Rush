using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {

    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower towerPrefab;
    [SerializeField] Transform towerParentTransform;

    Queue<Tower> towerQueue = new Queue<Tower>();


    

    public void AddTower(Waypoint basewaypoint)
    {
        int numTowers = towerQueue.Count;
        
        if (numTowers < towerLimit)
        {
            InstantiateNewTower(basewaypoint);
        }
        else
        {
            MoveExisitingTower(basewaypoint);
        }
    }

    private void MoveExisitingTower(Waypoint newbasewaypoint)
    {
        var oldTower = towerQueue.Dequeue();
        oldTower.basewaypoint.isPlaceable = true;
        newbasewaypoint.isPlaceable = false;
        towerQueue.Enqueue(oldTower);

        oldTower.basewaypoint = newbasewaypoint;

        oldTower.transform.position = newbasewaypoint.transform.position;
    }

    private void InstantiateNewTower(Waypoint basewaypoint)
    {
       var newTower = Instantiate(towerPrefab, basewaypoint.transform.position, Quaternion.identity);
        newTower.transform.parent = towerParentTransform;
       basewaypoint.isPlaceable = false;

       newTower.basewaypoint = basewaypoint;
    

       towerQueue.Enqueue(newTower);
    }
}
