using System.Collections;
using UnityEngine;

public class ProjectileComponent : MonoBehaviour
{
//    ProjectileSystem m_projectileSystem;
//    bool m_isActive = false;

    Vector3 m_direction = Vector3.zero;
    float m_speed = 0;


    private void Start()
    {
/*        m_projectileSystem = ProjectileSystem.GetInstance();
        m_projectileSystem.RegisterProjectile(this);*/
        //gameObject.SetActive(false);
    }

    private void Update()
    {
//        if (m_isActive)
//        {
            transform.Translate(m_direction * m_speed * Time.deltaTime);
//        }
    }

    internal void FireProjectile(Vector3 _direction, float _speed)
    {
//        m_isActive = true;
        m_direction = _direction;
        m_speed = _speed;
        //StartCoroutine(DisableObjectDelayed(5));
    }

/*    private void OnCollisionEnter(Collision collision)
    {
        //Delay 0.1 to allow the physics collision to happen
        StopAllCoroutines(); // Stop the 5 second trigger started earlier
        StartCoroutine(DisableObjectDelayed(0.1f));
    }


    private IEnumerator DisableObjectDelayed(float _delay)
    {
        yield return new WaitForSeconds(_delay);
        //m_isActive = false;
        gameObject.SetActive(false);
    }*/

/*    private void OnDestroy()
    {
        if (m_projectileSystem != null) { m_projectileSystem.UnregisterProjectile(this); }
    }
}*/
}
