using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGameStarted;

    public void StartGame()
    {
        isGameStarted = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            isGameStarted = true;
        }
    }
}