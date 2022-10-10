using System.Collections;
using UnityEngine;

public class ProjectileComponent : MonoBehaviour
{
    bool m_isActive = false;

    Vector3 m_direction = new Vector3(1,0,0);
    float m_speed = 0;
    float m_damage = 0;


    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (m_isActive)
        {
            transform.Translate(m_direction * m_speed * Time.deltaTime);
        }
    }

    internal void FireProjectile(float _speed, float _damage)
    {
        m_isActive = true;
        m_speed = _speed;
        m_damage = _damage;
        StartCoroutine(DisableObjectDelayed(5));
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Delay 0.1 to allow the physics collision to happen
        StopAllCoroutines(); // Stop the 5 second trigger started earlier
        StartCoroutine(DisableObjectDelayed(0.1f));
        if (collision.gameObject.GetComponent<EnemyComponent>())
        {
            collision.gameObject.GetComponent<EnemyComponent>().TakeDamage(m_damage);
        }
        else {
            Debug.Log("Projectile hit something else");
        }
    }


    private IEnumerator DisableObjectDelayed(float _delay)
    {
        yield return new WaitForSeconds(_delay);
        m_isActive = false;
        gameObject.SetActive(false);
    }
}
