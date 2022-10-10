using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>

{
    private List<GameObject> enemies = new List<GameObject>();

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

    public void AddEnemy(GameObject enemy)
    {
        enemies.Add(enemy);
    }

    public void RemoveEnemy(GameObject enemy)
    {
        enemies.Remove(enemy);
    }
}
