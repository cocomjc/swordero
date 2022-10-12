using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private GameObject target;
    public float speed = 5f;

    void Start()
    {
        target = GameObject.FindGameObjectsWithTag("Player")[0];
    }

    void Update()
    {
        if (target) {
            Vector3 direction = target.transform.position;
            direction.y = transform.position.y;
            transform.LookAt(direction);
        }
    }

    void FixedUpdate()
    {
        if (target) {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
