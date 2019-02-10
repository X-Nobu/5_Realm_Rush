using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EditorSnap : MonoBehaviour {

    //puts a field in the cube game object that makes gridsize 10 by default and can be adjusted between range 1f-20f
    [SerializeField] [Range(1f, 20f)] float gridSize = 10f;
    void Update()
    {
        Vector3 snapPos;
        // example postion 16/gridsize rounds to 2 mulitplied by gridsize give amount of snapping
        snapPos.x = Mathf.RoundToInt(transform.position.x/gridSize) * gridSize;

        snapPos.z = Mathf.RoundToInt(transform.position.z/gridSize) * gridSize;

        transform.position = new Vector3(snapPos.x, 0f, snapPos.z);
    }

}
