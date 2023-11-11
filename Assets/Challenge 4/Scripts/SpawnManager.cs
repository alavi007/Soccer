using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;

    private float spawnRangeX = 7;
    
    public int enemyCount;
    public int waveNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        Instantiate(powerupPrefab, GenerateSpawnPositionPowerup(), powerupPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }

        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerupPrefab, GenerateSpawnPositionPowerup(), powerupPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPositionEnemy()
    {
        float spawnPosX = Random.Range(-spawnRangeX, spawnRangeX);
        float spawnPosZ = Random.Range(16, 21);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    private Vector3 GenerateSpawnPositionPowerup()
    {
        float spawnPositionX = Random.Range(-5, 5);
        float spawnPositionZ = Random.Range(0, 4);

        Vector3 randomPos = new Vector3(spawnPositionX, 0, spawnPositionZ);
        return randomPos;
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPositionEnemy(), enemyPrefab.transform.rotation);
        }
    }
}
