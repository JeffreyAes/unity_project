using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpitterMaterial : MonoBehaviour
{
    Vector3 playerPosition;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        playerPosition = FindObjectOfType<PlayerBody>().transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerPosition, speed * Time.deltaTime);

        if (transform.position  == playerPosition){
            Destroy(gameObject);
        }
    }
}
