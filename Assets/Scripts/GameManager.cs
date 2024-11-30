using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject FishingCanvas;
    public GameObject AquariumCanvas;
    public int fishCount = 0;
    public SpawnFish spawnFish;

    public int activeScene = 1; 

    // Start is called before the first frame update
    void Start()
    {
        SwitchToFishing();
    }

    // Update is called once per frame
    void Update()
    {
        if (fishCount == 0)
        {
            spawnFish.SpawnObjects();
        }
    }

    public void SwitchToAquarium()
    {
        FishingCanvas.SetActive(false);
        AquariumCanvas.SetActive(true);

        activeScene = 2;
    }

    public void SwitchToFishing()
    {
        FishingCanvas.SetActive(true);
        AquariumCanvas.SetActive(false);

        activeScene = 1;
    }
}
