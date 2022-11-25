using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grounded : MonoBehaviour
{
    [SerializeField] private int jumps = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        print("Collided");
    }
}
