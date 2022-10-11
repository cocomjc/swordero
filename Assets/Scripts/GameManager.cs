using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    void Start()
    {
        SceneManager.LoadScene("Menu Scene", LoadSceneMode.Additive);
    }

    public void StartGame()
    {
        SceneManager.UnloadSceneAsync("Menu Scene");
        SceneManager.LoadScene("Player Scene", LoadSceneMode.Additive);
        SceneManager.LoadScene("UI Scene", LoadSceneMode.Additive);
        SceneManager.LoadScene("Level 1", LoadSceneMode.Additive);
    }

    public void EndGame()
    {
        SceneManager.UnloadSceneAsync("Player Scene");
        SceneManager.UnloadSceneAsync("UI Scene");
        SceneManager.UnloadSceneAsync("Level 1");
        SceneManager.LoadScene("Menu Scene", LoadSceneMode.Additive);
    }
}
