
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject enemy;
    private GameObject player;
    private Transform playerTransform;
    private float spawnInterval = 2;
    private float startDelay = 1.0f;
    private float spawnRangeX;
    private float spawnRangeZ;
    //int firstRow = 0;
    //int secondRow = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        enemy = GameObject.Find("EnemyBasic Variant");
        playerTransform = player.transform;
        spawnRangeX = enemy.GetComponent<Enemy>().getXBounds();
        spawnRangeZ = enemy.GetComponent<Enemy>().getZBounds();
        InvokeRepeating("SpawnEnemyBasic", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnEnemyBasic()
    {
        //int spawnAngle = player.GetComponent<PlayerController>.getgetSpawnAngle();
        spawnInterval = Random.Range(0.1f, 8.0f);
        //Debug.Log(spawnInterval);
        Vector3 playerPos = playerTransform.position;
        int posXRange = (int)Random.Range(spawnRangeX, spawnRangeX + 10);
        int negXRange = (int)Random.Range(-spawnRangeX, -spawnRangeX - 10);
        int posZRange = (int)Random.Range(spawnRangeX, spawnRangeX + 10);
        int negZRange = (int)Random.Range(-spawnRangeX, -spawnRangeX - 10);
        bool coinFlip = false;
        if (Random.Range(0,1) >= 1) 
        {
            coinFlip = true;
        }
        Vector3 spawnPos;
        if (coinFlip)
        {
             spawnPos = new Vector3(posXRange, 0, posZRange);
        }
        else 
        {
             spawnPos = new Vector3(negXRange, 0, negZRange);
        }
        int enemyIndex = Random.Range(0, enemies.Length);
        Instantiate(enemies[enemyIndex], spawnPos, enemies[enemyIndex].transform.rotation);
    }
}