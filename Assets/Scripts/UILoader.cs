using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UILoader : MonoBehaviour
{
    void Awake()
    {
        SceneManager.LoadScene("UI Scene", LoadSceneMode.Additive);
    }
}
