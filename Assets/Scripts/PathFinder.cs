using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    EnemySpawner spawner;
    List<Transform> path;
    WaveConfigSO waveConfig;
    int waypointIndex = 0;

   void Awake()
    {
        spawner = FindObjectOfType<EnemySpawner>();
    }

    void Start()
    {
        waveConfig = spawner.GetCurrentWave();
        path = waveConfig.GetWaypoints();
        transform.position = path[waypointIndex].position;
    }

    
    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        if(waypointIndex < path.Count)
        {
            Vector3 location = path[waypointIndex].position;
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, location, delta);
            if(transform.position ==  location)
            {
                waypointIndex++;
            }
            
        }
        else
            {
                Destroy(gameObject);
            }
    }
}
