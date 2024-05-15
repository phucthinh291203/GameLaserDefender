using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 [CreateAssetMenu(menuName = "Wave config",fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefab;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float timeBetweenEnemySpawn = 1f;
    [SerializeField] float spawnTimeVariance =0.5f;
    [SerializeField] float minimumSpawnTime = 0.2f;
    public int GetEnemyCount()
    {
        return enemyPrefab.Count;
    }

    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefab[index];
    }
    public Transform GetStartingWaypoint()
    {
        return pathPrefab.GetChild(0);
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public List<Transform> GetWaypoints()
    {
        List<Transform> path = new List<Transform>();
        foreach(Transform waypoint in pathPrefab)
        {
            path.Add(waypoint);
        }
        return path;
    }

    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(timeBetweenEnemySpawn - spawnTimeVariance
            , timeBetweenEnemySpawn + spawnTimeVariance);
        return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
    }
}
