using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBehavior : MonoBehaviour
{
    GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.GetInstance();
    }

    public void StartGame()
    {
        gameManager.StartGame();
    }
}
