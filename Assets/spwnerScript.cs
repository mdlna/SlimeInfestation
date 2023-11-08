using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[System.Serializable]
public class Wave
{
    public string waveName;
    public int noOfEnemies;
    public GameObject enemy;
    public float spawnInterval;
}

public class spwnerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Wave[] waves;
    public Transform spawnPoint;

    private Wave currentWave;
    private int currentWaveNo;
    private bool shouldSpawn = true;
    private float nextSpawnTime;
    private void Update()
    {
        currentWave = waves[currentWaveNo];
        

        SpawnWave();
        GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("enemy");

        if (totalEnemies.Length == 0 && !shouldSpawn && currentWaveNo+1!=waves.Length)
        {
            SpawnNextWave();
        }
        if(currentWaveNo == waves.Length-1)
        {
            SceneManager.LoadScene(3);
        }
    }

    void SpawnNextWave()
    {
        currentWaveNo++;
        shouldSpawn = true;
    }
    void SpawnWave()
    {
        if(shouldSpawn && nextSpawnTime < Time.time)
        {
            GameObject currentEnemy = currentWave.enemy;
            Transform spawn = spawnPoint;
            Instantiate(currentEnemy, spawn);

            currentWave.noOfEnemies--;
            nextSpawnTime = Time.time + currentWave.spawnInterval;
            if(currentWave.noOfEnemies == 0)
            {
                shouldSpawn = false;
            }
        }
        
    }


}
