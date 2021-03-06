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
        SpawnCoins();
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

    public GameObject coinPrefab;

    void SpawnCoins()
    {
        int coinsToSpawn = 10;
        for (int i = 0; i < coinsToSpawn; i++)
        {
            GameObject temp = Instantiate(coinPrefab, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }

    Vector3 GetRandomPointInCollider (Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
             Random.Range(collider.bounds.min.y, collider.bounds.max.y),
              Random.Range(collider.bounds.min.z, collider.bounds.max.z));
        if(point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);
        }

        point.y = 1;
        return point;
    }
}

