using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class WaveSpawner : MonoBehaviour
{
    [System.Serializable]
    public struct Wave
    {
        public Enemy[] enemies;
        public int count;
        public int timeBetweenSpawn;
    }
    [SerializeField] Wave[] waves;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] float timeBetweenWaves;

    Wave currentWave;
    [HideInInspector]public int currentWaveIndex;
    Transform player;
    bool isSpawnFinish = false;
    bool isFreeTime;
    float currentTimeBetweenWave;
    [SerializeField] GameObject spawnEffect;

    [SerializeField] TextMeshProUGUI waveText;


    private void Start()
    {
        player = ScriptTwo.instance.transform;
        currentTimeBetweenWave = timeBetweenWaves;
        UpdateText();
        StartCoroutine(CallNextWave(currentWaveIndex));
    }
    IEnumerator CallNextWave(int waveIndex)
    {
        currentTimeBetweenWave = timeBetweenWaves;
        isFreeTime = true;
        yield return new WaitForSeconds(timeBetweenWaves);
        isFreeTime = false;
        StartCoroutine(SpawnWave(waveIndex));
    }

    private void Update()
    {
        UpdateText();

        if (isSpawnFinish && GameObject.FindGameObjectsWithTag("enemy").Length == 0)
        {
            isSpawnFinish = false;

            if(currentWaveIndex + 1 < waves.Length)
            {
                
                currentWaveIndex++;
                
                StartCoroutine(CallNextWave(currentWaveIndex));
            }
        }
    }

    void UpdateText()
    {
        if (isFreeTime) waveText.text = "До следующей волны " + ((int)(currentTimeBetweenWave -= Time.deltaTime)).ToString();
        else waveText.text = "Волна " + currentWaveIndex.ToString();
    }
    IEnumerator SpawnWave(int waveIndex)
    {
        currentWave = waves[waveIndex];
        for (int i = 0; i < currentWave.count; i++)
        {
            if (player == null) yield break;
            Enemy randomEnemy = currentWave.enemies[Random.Range(0, currentWave.enemies.Length)];
            Transform randomSpawnPoints = spawnPoints[Random.Range(0, spawnPoints.Length)];

            Instantiate(randomEnemy, randomSpawnPoints.position, Quaternion.identity);
            Instantiate(spawnEffect, randomSpawnPoints.position, Quaternion.identity);

            if (i == currentWave.count - 1)
            {
                isSpawnFinish = true;
            }
            else isSpawnFinish = false;

            yield return new WaitForSeconds(currentWave.timeBetweenSpawn);
        }

        

    }
}