
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject[] enemies;//Kinda useless since there is only one enemy.
    public GameObject enemy;//Used as a static enemy to get properties from.
    public GameObject gameManager;
    private GameObject player;
    private Transform playerTransform;
    private float spawnInterval = 2;
    private float spawnRangeX;
    private float spawnRangeZ;
    public float timeDiff = 0.0f;
    public float difficulty;
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
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        spawnInterval -= Time.deltaTime;
        if (spawnInterval < 0) StartCoroutine(spawnEnemy());
        if (timeDiff < 6) 
        {
            timeDiff = gameManager.GetComponent<GameManager>().seconds / 10;
        }
    }
    IEnumerator spawnEnemy() 
    {
        SpawnEnemyBasic();
        yield return new WaitForSeconds(spawnInterval);
    }
    void SpawnEnemyBasic()
    {
        //int spawnAngle = player.GetComponent<PlayerController>.getgetSpawnAngle();
        spawnInterval = Random.Range(0.1f, 8.0f - timeDiff);//Modifies spawn timing based on how long the game has gone on for.
        Vector3 playerPos = playerTransform.position;//Gets player position, and uses it to spawn enemies.
        int posXRange = (int)Random.Range(spawnRangeX, spawnRangeX + 10);
        int negXRange = (int)Random.Range(-spawnRangeX, -spawnRangeX - 10);
        int posZRange = (int)Random.Range(spawnRangeX, spawnRangeX + 10);
        int negZRange = (int)Random.Range(-spawnRangeX, -spawnRangeX - 10);
        bool coinFlip = false;
        if (Random.Range(0,2) >= 1) 
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