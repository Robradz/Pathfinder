using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    [SerializeField] Transform objectToPan;

    [SerializeField] float range = 50f;
    [SerializeField] ParticleSystem bullets;
    GameObject[] enemies;
    GameObject closest;
    float closestDistance;
    int enemiesPresent;

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        FollowClosestEnemy();
        ShootInRange();
    }

    private void ShootInRange()
    {
        bool inRange;

        try
        { 
            inRange = Vector3.Distance(gameObject.transform.position, closest.transform.position) <= range;
        }
        catch
        {
            inRange = false;
        }

        var emission = bullets.emission;
        emission.enabled = enemies.Length > 0 && inRange;
    }

    private void FollowClosestEnemy()
    {

        // Finds all enemies in game to choose closest one
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length <= 0)
        {
            enemiesPresent = 0;
            return;
        }

        // closest enemy is found by looking at the distance of each enemy, with the first one in the array being the default
        closest = enemies[0];
        closestDistance = Vector3.Distance(closest.transform.position, gameObject.transform.position);

        foreach (GameObject enemy in enemies)
        {
            float enemyDistance = Vector3.Distance(enemy.transform.position, gameObject.transform.position);
            if (enemyDistance < closestDistance)
            {
                closest = enemy;
                closestDistance = enemyDistance;
            }
        }

        objectToPan.LookAt(closest.transform);
    }
}
