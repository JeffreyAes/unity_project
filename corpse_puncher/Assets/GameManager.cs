using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    bool gameHasEnded;

    public void GameOver()
    {
        if(gameHasEnded == false)
        {
        gameHasEnded = true;
        Debug.Log("Ending game lol");
        Invoke("RestartGame", 3f);
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }  
}
