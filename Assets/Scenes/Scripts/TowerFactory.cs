using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {

    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower towerPrefab;

    int numTowers = 0;

    public void AddTower(Waypoint basewaypoint)
    {
        
        if (numTowers < towerLimit)
        {
            InstantiateNewTower(basewaypoint);
        }
        else
        {
            MoveExsitingTower();
        }
    }

    private static void MoveExsitingTower()
    {
        Debug.Log("Max towers reached");
    }

    private void InstantiateNewTower(Waypoint basewaypoint)
    {
        Instantiate(towerPrefab, basewaypoint.transform.position, Quaternion.identity);
        basewaypoint.isPlaceable = false;
        numTowers++;
    }
}
