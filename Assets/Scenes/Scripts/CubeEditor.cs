using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor : MonoBehaviour {

    //puts a field in the cube game object that makes gridsize 10 by default and can be adjusted between range 1f-20f
    [SerializeField] [Range(1f, 20f)] float gridSize = 10f;
    

    TextMesh textMesh;

    void Start()
    {
      
    }

    void Update()
    {
        Vector3 snapPos;
        
        // example postion 16/10 rounds to 2 mulitplied by 10 give amount of snapping 20
        snapPos.x = Mathf.RoundToInt(transform.position.x/gridSize) * gridSize;
        snapPos.z = Mathf.RoundToInt(transform.position.z/gridSize) * gridSize;
        transform.position = new Vector3(snapPos.x, 0f, snapPos.z);

        textMesh = GetComponentInChildren<TextMesh>();
        string labelText = snapPos.x / gridSize + "," + snapPos.z / gridSize;
        textMesh.text = labelText;
        gameObject.name = labelText;

        
    }

}
