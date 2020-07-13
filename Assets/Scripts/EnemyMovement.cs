using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float enemyHeight = 5;
    // Start is called before the first frame update
    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        foreach (Waypoint waypoint in path)
        {
            transform.position = new Vector3 (waypoint.transform.position.x, enemyHeight, waypoint.transform.position.z);
            yield return new WaitForSeconds(1f);
        }
    }

    public float GetHeight()
    {
        return enemyHeight;
    }
}
