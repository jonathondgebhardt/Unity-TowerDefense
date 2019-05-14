using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class WaveSpawner : MonoBehaviour
{
    public Transform enemy;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;
    public float timeBetweenEnemies = 0.5f;
    public Text waveCountDownText;

    private float waveTimer = 2f;
    private int waveNumber = 0;

    void Update()
    {
        if(waveTimer <= 0f)
        {
            StartCoroutine(SpawnWave());
            waveTimer = timeBetweenWaves;
        }

        waveTimer -= Time.deltaTime;

        waveCountDownText.text = Mathf.Floor(waveTimer + 1).ToString();
    }

    IEnumerator SpawnWave()
    {
        ++waveNumber;

        for (int i = 0; i < waveNumber; ++i)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(timeBetweenEnemies);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
