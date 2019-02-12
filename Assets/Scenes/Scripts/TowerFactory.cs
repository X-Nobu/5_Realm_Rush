using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {

    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower towerPrefab;

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

    private void MoveExisitingTower(Waypoint basewaypoint)
    {
        var oldTower = towerQueue.Dequeue();
        basewaypoint.isPlaceable = true;

        towerQueue.Enqueue(oldTower);
    }

    private void InstantiateNewTower(Waypoint basewaypoint)
    {
       var newTower = Instantiate(towerPrefab, basewaypoint.transform.position, Quaternion.identity);
       basewaypoint.isPlaceable = false;

        towerQueue.Enqueue(newTower);
    }
}
