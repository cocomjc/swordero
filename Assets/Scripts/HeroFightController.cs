using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroFightController : MonoBehaviour
{
 //   private bool isStill = false;
    //private bool isAttacking = false;

    private void Update() {
/*        if (isStill && enemies.Count > 0 && !isAttacking) {
            isAttacking = true;
            this.gameObject.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Attack");
            GameObject target = GetClosestEnemy();
            transform.LookAt(target.transform);
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + 180, 0);

            /*            Destroy(enemies[0]);
                        enemies.RemoveAt(0);*/
//            Debug.Log("Enemy killed, " + enemies.Count + " enemies left");
//        }
    }    
}
