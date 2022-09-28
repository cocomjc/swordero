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

    public void Fire(Vector3 _target)
    {
        //StartCoroutine(FireDelayed(0.4f, _target));
        //Instantiate(projectilePrefabs[0], transform.position, Quaternion.identity).GetComponent<ProjectileComponent>();
        ProjectileComponent projectile = GetComponent<ObjectPool>().GetPooledObject().GetComponent<ProjectileComponent>();
        projectile.gameObject.SetActive(true);
        projectile.transform.position = transform.position;
        //projectile.transform.LookAt(_target);
        Vector3 direction = (_target - transform.position).normalized;
        projectile.FireProjectile(direction, _speed);        
    }

    private IEnumerator FireDelayed(float _delay, Vector3 _target)
    {
        yield return new WaitForSeconds(_delay);
        ProjectileComponent projectile = GetComponent<ObjectPool>().GetPooledObject().GetComponent<ProjectileComponent>();
        projectile.gameObject.SetActive(true);
        projectile.transform.position = transform.position;
        //projectile.transform.LookAt(_target);
        Vector3 direction = (_target - transform.position).normalized;
        projectile.FireProjectile(direction, _speed);
    }
}
