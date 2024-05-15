using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveList;
    [SerializeField] float timeBetweenWave = 0f;
    WaveConfigSO currentWave;
    bool isLooping = true;
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

  

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }
    
     IEnumerator SpawnEnemy()
     {
        do
        {
            foreach (WaveConfigSO wave in waveList)
            {
                currentWave = wave;
                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(currentWave.GetEnemyPrefab(i),
                              currentWave.GetStartingWaypoint().position,
                              Quaternion.Euler(0,0,180),
                              transform);  // tat ca nhung enemy sinh ra duoc nam ben trong object cha
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenWave);
            }
        } while (isLooping);
     }
}
