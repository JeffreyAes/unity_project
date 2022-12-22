using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorpseDestroy : MonoBehaviour
{
    private float timeToDestroy = 20;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyCorpse", timeToDestroy);
    }

    // Update is called once per frame
    void DestroyCorpse()
    {
        Destroy(gameObject);
    }
}
