using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    // public GameOverScreen GameOverScreen;
    bool gameHasEnded;

    public void GameOver()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            // GameOverScreen.setUp();
            // Debug.Log("Ending game lol");
        }
    }

    
    
}