using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float minRangeSpawnInSec;
    public float maxRangeSpawnInSec;
    
    private readonly Vector3 _spawnPos = new Vector3(25, 0, 0);
    private float _lastSpawnTime = Time.time;
    private float _spawnCoolDown = 0;

    // Update is called once per frame
    void Update()
    {
        if (Time.time - _lastSpawnTime > _spawnCoolDown)
        {
            SpawnObstacle();
            _lastSpawnTime = Time.time;
            _spawnCoolDown = Random.Range(minRangeSpawnInSec, maxRangeSpawnInSec);
        }
    }

    private void SpawnObstacle()
    {
        Instantiate(obstaclePrefab, _spawnPos, obstaclePrefab.transform.rotation);
    }
}
