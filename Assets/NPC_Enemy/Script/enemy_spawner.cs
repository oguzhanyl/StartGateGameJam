using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    public GameObject theEnemy;
    public int xPos;
    public int zPos;
    public int EnemyCount;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (EnemyCount < 21)
        {
            xPos = Random.Range(-10, 10);
            zPos = Random.Range(-10, 10);
            Instantiate(theEnemy, new Vector3(xPos, 1, zPos), Quaternion.identity);
            yield return new WaitForSeconds(1f);
            EnemyCount += 1;
            if (EnemyCount == 20)
            {
                Debug.Log("KIRILDI");
                break;
            }
        }
    }
}