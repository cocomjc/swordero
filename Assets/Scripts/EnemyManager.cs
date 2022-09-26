using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    private List<GameObject> enemies = new List<GameObject>();

    public void SetUpEnemyList()
    {
        foreach (Transform child in transform)
        {
            enemies.Add(child.gameObject);
        }
    }

    public GameObject GetClosestEnemy(Vector3 playerPos)
    {
        float minDistance = Mathf.Infinity;
        GameObject closestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            if (Vector3.Distance(playerPos, enemy.transform.position) < minDistance)
            {
                minDistance = Vector3.Distance(playerPos, enemy.transform.position);
                closestEnemy = enemy;
            }
        }
        return closestEnemy;
    }

    public bool EnemyExists()
    {
        return enemies.Count > 0;
    }
}
