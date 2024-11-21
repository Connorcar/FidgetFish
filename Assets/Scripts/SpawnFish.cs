using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFish : MonoBehaviour
{
    public GameObject fishPrefab; // The prefab to spawn
    public float xAxis;        // Fixed Y-axis position for spawning
    public float minY;       // Minimum X-axis range
    public float maxY;        // Maximum X-axis range
    public int objectCount;    // Number of objects to spawn
    public Transform fishParent;  // Parent object for the spawned objects

    void Start()
    {
        SpawnObjects();
    }

    void SpawnObjects()
    {
        Vector3 spawnPosition = Vector3.zero;
        for (int i = 0; i < objectCount; i++)
        {
            // Generate a random X position
            float randomY = Random.Range(minY, maxY);

            // Create the spawn position with the fixed Y-axis
            spawnPosition = new Vector3(xAxis, randomY, 0f);

            // Instantiate the objectPrefab at the spawn position
            Instantiate(fishPrefab, spawnPosition, Quaternion.identity, fishParent);
        }
        spawnPosition.y = 200;
        Instantiate(fishPrefab, spawnPosition, Quaternion.identity, fishParent);
    }
}
