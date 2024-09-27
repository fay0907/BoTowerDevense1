using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;

    public int enemiesPerWave = 5;
    public float timeBetweenWaves = 60f;

    private int waveCount = 0;
    private float nextWaveTime = 0f;

    void Update()
    {
        if (Time.time >= nextWaveTime)
        {
            SpawnWave();
            nextWaveTime = Time.time + timeBetweenWaves;
        }
    }

    void SpawnWave()
    {
        waveCount++;
        Debug.Log("Wave " + waveCount);

        for (int i = 0; i < enemiesPerWave; i++)
        {
            Transform spawnPoint = spawnPoints[Random.Range(10, spawnPoints.Length)];
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}