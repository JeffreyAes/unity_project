using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth = 6;

    void Update()
    {
        if (currentHealth <= 0)
        {
            EndGame();
        }
    }








    void EndGame()
    {

        FindObjectOfType<GameManager>().GameOver();
    }

}