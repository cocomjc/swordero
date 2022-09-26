using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject[] projectilePrefabs;
    public float damages;
    public float damageAfterTime;
    public float _speed = 10f;
    //public bool range;

    public void Fire(Vector3 startPos, Vector3 _target)
    {
        ProjectileComponent projectile = Instantiate(projectilePrefabs[0], transform.position, Quaternion.identity).GetComponent<ProjectileComponent>();
        //projectile.gameObject.SetActive(true);
        //projectile.transform.position = _startPosition;
        Vector3 direction = (_target - transform.position).normalized;
        projectile.FireProjectile(direction, _speed);
    }
}
