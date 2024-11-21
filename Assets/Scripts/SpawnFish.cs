using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFish : MonoBehaviour
{
    public GameObject fishPrefab; // The prefab to spawn
    public float minX;       // Minimum X-axis range
    public float maxX;        // Maximum X-axis range        
    public float minY;       // Minimum X-axis range
    public float maxY;        // Maximum X-axis range
    public int objectCount;    // Number of objects to spawn
    public Transform fishParent;  // Parent object for the spawned objects
    public GameManager gm;

    void Start()
    {
        SpawnObjects();
    }

    public void SpawnObjects()
    {
        Vector3 spawnPosition = Vector3.zero;
        for (int i = 0; i < objectCount; i++)
        {
            // Generate a random position
            float randomY = Random.Range(minY, maxY);
            float randomX = Random.Range(minX, maxX);

            // Create the spawn position with the fixed Y-axis
            spawnPosition = new Vector3(randomX, randomY, 0f);

            // Instantiate the objectPrefab at the spawn position
            Instantiate(fishPrefab, spawnPosition, Quaternion.identity, fishParent);
        }
        gm.fishCount = objectCount;

        //for testing lowest spawn position
        // spawnPosition.y = 200;
        // Instantiate(fishPrefab, spawnPosition, Quaternion.identity, fishParent);
    }
}
