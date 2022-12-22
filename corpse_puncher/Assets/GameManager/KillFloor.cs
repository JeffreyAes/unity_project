using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillFloor : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        print("I am a killbox");
    }
}
