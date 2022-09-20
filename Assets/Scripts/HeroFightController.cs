using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroFightController : MonoBehaviour
{
    private bool isStill = false;
    private List<GameObject> enemies;
    private bool isAttacking = false;

    private void Start() {
        enemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
    }

    private void Update() {
        if (isStill && enemies.Count > 0 && !isAttacking) {
            isAttacking = true;
            this.gameObject.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Attack");
            Destroy(enemies[0]);
            enemies.RemoveAt(0);
            Debug.Log("Enemy killed, " + enemies.Count + " enemies left");
        }
    }

    public void SetStill(bool isRunning)
    {
        isStill = !isRunning;
    }

    public void SetAttacking(bool newVal)
    {
        isAttacking = newVal;
    }
}
