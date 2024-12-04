using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFish : MonoBehaviour
{
    public GameObject[] fishPrefabs; // List of fish prefabs to spawn
    public int[] fishDepths; // List of fish depths
    public int[] fishSpeeds; // List of fish speeds
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
            //odds for generating fish
            float randomValue = Random.Range(0f, 1f); 
            int randomFish = 0;
            // Determine which condition is met based on the cumulative probabilities
            if (randomValue < 0.15f) // 15% chance
            {
                randomFish = 0;
            }
            else if (randomValue < 0.30f) // 15% chance
            {
                randomFish = 1;
            }
            else if (randomValue < 0.45f) // 15% chance
            {
                randomFish = 2;
            }
            else if (randomValue < 0.55f) // 10% chance
            {
                randomFish = 3;
            }
            else if (randomValue < 0.65f) // 10% chance
            {
                randomFish = 4;
            }
            else if (randomValue < 0.75f) // 10% chance
            {
                randomFish = 5;
            }
            else if (randomValue < 0.85f) // 10% chance
            {
                randomFish = 6;
            }
            else if (randomValue < 0.90f) // 5% chance
            {
                randomFish = 7;
            }
            else if (randomValue < 0.95f) // 5% chance
            {
                randomFish = 8;
            }
            else // Remaining 5% chance
            {
                randomFish = 9;
            }
            
            // Generate a random position
            minY = fishDepths[randomFish];
            maxY = fishDepths[randomFish+1];
            float randomY = Random.Range(minY, maxY);
            float randomX = Random.Range(minX, maxX);

            // Create the spawn position with the fixed Y-axis
            spawnPosition = new Vector3(randomX, randomY, 0f);

            // Instantiate the objectPrefab at the spawn position
            GameObject newFish = Instantiate(fishPrefabs[randomFish], spawnPosition, Quaternion.identity, fishParent);
            newFish.GetComponent<FishMovement>().setSpeed(fishSpeeds[randomFish]);
        }
        gm.fishCount += objectCount;

        //for testing lowest spawn position
        // spawnPosition.y = 200;
        // Instantiate(fishPrefab, spawnPosition, Quaternion.identity, fishParent);
    }
}
