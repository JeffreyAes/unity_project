using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> EnemiesToSpawn = new List<GameObject>();
    public GameObject Runner;
    public GameObject Spitter;
    public int xPos;
    public int zPos;
    GameObject[] enemyCount;
    public int maxEnemyCount = 20;
    public List<Vector3> SpawnPoints = new List<Vector3>();


    void Start()
    {
        EnemiesToSpawn.Add(Runner);
        EnemiesToSpawn.Add(Spitter);

        enemyCount = GameObject.FindGameObjectsWithTag("Enemy");
        Vector3 spawn1 = new Vector3(-100, 15, -8);
        Vector3 spawn2 = new Vector3(-66, 23, -52);
        Vector3 spawn3 = new Vector3(-181, 34, -44);
        Vector3 spawn4 = new Vector3(-176, 22, 13);
        Vector3 spawn5 = new Vector3(-224, 30, 51);
        Vector3 spawn6 = new Vector3(-166, 25, 18);
        SpawnPoints.Add(spawn1);
        SpawnPoints.Add(spawn2);
        SpawnPoints.Add(spawn3);
        SpawnPoints.Add(spawn4);
        SpawnPoints.Add(spawn5);
        SpawnPoints.Add(spawn6);

        StartCoroutine(EnemyDrop());
    }

    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy");
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount.Length <= maxEnemyCount)
        {
            // for spawning randomly if i so want to
            // xPos = Random.Range(-117, -95);
            // zPos = Random.Range(-25, 4);
            int rand = Random.Range(0, EnemiesToSpawn.Count);
            int randSpawn = Random.Range(0,SpawnPoints.Count);
            Instantiate(EnemiesToSpawn[rand], SpawnPoints[randSpawn], Quaternion.identity);

            yield return new WaitForSeconds(3f);
        }
    }





}
