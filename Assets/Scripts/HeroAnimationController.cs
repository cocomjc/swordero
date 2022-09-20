using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAnimationController : MonoBehaviour
{
    public void TriggerRun(bool isRunning)
    {
        this.gameObject.transform.GetChild(0).GetComponent<Animator>().SetBool("isRunning", isRunning);
    }
}
