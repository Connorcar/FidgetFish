using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Aquarium : MonoBehaviour
{
    public GameObject[] fishPrefabs; // List of possible fish prefabs to spawn
    public GameManager gm;          // Reference to the GameManager
    public float minX;                // Minimum X-axis range
    public float maxX;                // Maximum X-axis range
    public float minY;                // Minimum Y-axis range
    public float maxY;                // Maximum Y-axis range
    public Transform fishParent;    // Parent object for the spawned objects
    public RectTransform aquariumCanvasRectTransform;

    public void onAddFishClick()
    {
        // minX = 0;
        // maxX = aquariumCanvasRectTransform.rect.width;
        // minY = aquariumCanvasRectTransform.rect.height;
        // maxY = (aquariumCanvasRectTransform.rect.height*2 ) - (aquariumCanvasRectTransform.rect.height / 4);
        minX = 100;
        maxX = 1950;
        minY = 200;
        maxY = 800;
        Debug.Log("Add Fish Button Clicked");
        for (int i = 0; i < gm.maxFish; i++)
        {
            // Generate a random position
            float randomY = UnityEngine.Random.Range(minY, maxY);
            float randomX = UnityEngine.Random.Range(minX, maxX);

            // Create the spawn position with the fixed Y-axis
            Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);

            GameObject newFish;
            if(gm.caughtFishTiers[i] != 0)
            {
                // Instantiate the objectPrefab at the spawn position
                newFish = Instantiate(fishPrefabs[gm.caughtFishTiers[i] -1], spawnPosition, Quaternion.identity, fishParent);
            }
        }
        Array.Clear(gm.caughtFishTiers, 0, gm.caughtFishTiers.Length);
        gm.fishCaught = 0;
    }
}
