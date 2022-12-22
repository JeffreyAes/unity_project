using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public GameOverScreen GameOverScreen;
    public bool gameHasEnded = false;

    public void GameOver()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            GameOverScreen.setUp();
            Cursor.visible = true;
            UnityEngine.Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
            Debug.Log("Ending game lol");
        }
    }



}