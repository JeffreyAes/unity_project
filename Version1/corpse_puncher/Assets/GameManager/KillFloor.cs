using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillFloor : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
        EndGame();
        }
        

    }


    void EndGame()
    {

        FindObjectOfType<GameManager>().GameOver();
    }
}
