using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadTile : MonoBehaviour
{
    RoadSpawner roadSpawner;

    // Start is called before the first frame update
    void Start()
    {
        roadSpawner = GameObject.FindObjectOfType<RoadSpawner>();
        SpawnObstacles();
    }

    private void OnTriggerExit(Collider other)
    {
        roadSpawner.SpawnTile();
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject obstaclePrefab;

    void SpawnObstacles()
    {
        // Choose a random point to spam the obstacle
        int obstacleSpawnIndex = Random.Range(3, 7);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        // Spawn an obstacle at the position
        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }
}
