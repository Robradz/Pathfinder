using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float secondsBetweenSpawns;
    [SerializeField] GameObject enemy;
    [SerializeField] int numEnemies = 3;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < numEnemies; i++)
        {
            if (i > 0) { SpawnEnemy(); }
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }

    private void SpawnEnemy()
    {
        Instantiate<GameObject>(enemy, gameObject.transform);
    }
}
