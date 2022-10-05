using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    private HeroParameters heroParameters;
    [SerializeField] private float baseSpeed = 15f;
    private GameObject firePoint;

    private void Awake()
    {
        firePoint = GameObject.FindGameObjectsWithTag("FirePoint")[0];
        heroParameters = HeroParameters.GetInstance();
    }

    public void Fire(Vector3 _target)
    {
        StartCoroutine(FireDelayed(0.4f, _target));
    }
    
    private IEnumerator FireDelayed(float _delay, Vector3 _target)
    {
        yield return new WaitForSeconds(_delay);
        ProjectileComponent projectile = GetComponent<ObjectPool>().GetPooledObject().GetComponent<ProjectileComponent>();
        projectile.gameObject.SetActive(true);
        projectile.transform.position = firePoint.transform.position;
        projectile.transform.LookAt(_target);
        projectile.transform.Rotate(0, -90, 0);
        projectile.FireProjectile(baseSpeed * heroParameters.GetAttackSpeed());
    }

    public void CancelFire()
    {
        StopAllCoroutines();
    }
}
