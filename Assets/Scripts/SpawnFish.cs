using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFish : MonoBehaviour
{
    public GameObject[] fishPrefabs; // List of fish prefabs to spawn
    public float[] fishDepths; // List of fish depths
    public int[] fishSpeeds; // List of fish speeds
    public float minX;       // Minimum X-axis range
    public float maxX;        // Maximum X-axis range        
    public float minY;       // Minimum X-axis range
    public float maxY;        // Maximum X-axis range
    public int objectCount;    // Number of objects to spawn
    public Transform fishParent;  // Parent object for the spawned objects
    public GameManager gm;
    public RectTransform fishingCanvasRectTransform;

    void Awake()
    {
        minX = 0;
        maxX = fishingCanvasRectTransform.rect.width ;
        minY = 0;
        maxY = (fishingCanvasRectTransform.rect.height ) - (fishingCanvasRectTransform.rect.height / 4);
        // minX = 100;
        // maxX = 1080;
        // minY = 200;
        // maxY = 800;
        print("minX: " + minX + " maxX: " + maxX + " minY: " + minY + " maxY: " + maxY);

        fishDepths = new float[11];
        fishDepths[0] = maxY;
        fishDepths[10] = minY;
        for (int i = 1; i < 10; i++)
        {
            fishDepths[i] = maxY - (((maxY - minY) / 10)*i) ;
        }
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
            float tempMinY = fishDepths[randomFish];
            float tempMaxY = fishDepths[randomFish+1];
            float randomY = Random.Range(tempMinY, tempMaxY);
            float randomX = Random.Range(minX, maxX);

            // Create the spawn position with the fixed Y-axis
            spawnPosition = new Vector3(randomX, randomY, 0f);
            print("x: " + randomX + " y: " + randomY);

            // Instantiate the objectPrefab at the spawn position
            GameObject newFish = Instantiate(fishPrefabs[randomFish], spawnPosition, Quaternion.identity, fishParent);
            newFish.GetComponent<FishMovement>().setSpeed(fishSpeeds[randomFish]);
            newFish.GetComponent<FishMovement>().setx(minX, maxX);
        }
        gm.fishCount += objectCount;

        // for testing spawn position
        // spawnPosition = new Vector3(fishingCanvasRectTransform.rect.width/2, maxY, 0f);
        // Instantiate(fishPrefabs[0], spawnPosition, Quaternion.identity, fishParent);
    }
}
