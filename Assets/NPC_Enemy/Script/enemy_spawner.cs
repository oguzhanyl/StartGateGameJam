using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    public GameObject theEnemy;
    public float xPos;
    public float zPos;
    public int EnemyCount;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (EnemyCount < 11)
        {
            //xPos = Random.Range(-10, 10);
            //zPos = Random.Range(-10, 10);
            Instantiate(theEnemy, new Vector3(xPos, 7, zPos), Quaternion.identity);
            yield return new WaitForSeconds(4f);
            EnemyCount += 1;
            if (EnemyCount == 10)
            {
                Debug.Log("GEÇÝT KIRILIYOR");
                break;
            }
        }
    }
}