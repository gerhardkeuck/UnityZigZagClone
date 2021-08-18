using System;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void EndGame()
    {
        isGameStarted = false;
        SceneManager.LoadScene("Main");
    }
}