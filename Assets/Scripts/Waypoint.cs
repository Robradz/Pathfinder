using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    Vector2Int gridPos;

    const int gridSize = 10;

    public bool isExplored = false;
    public Waypoint exploredFrom;



    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            (int)Mathf.Round(transform.position.x / gridSize), 
            (int)Mathf.Round(transform.position.z / gridSize));
    }

    public int GetGridSize()
    {
        return gridSize;
    }

    public void SetTopColor(Color color)
    {
        MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = color;
    }
}
