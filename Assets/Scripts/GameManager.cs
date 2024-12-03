using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject FishingCanvas;
    public GameObject AquariumCanvas;
    public int fishCount = 0;
    public SpawnFish spawnFish;
    public int fishCaught = 0;
    public int[] caughtFishTiers;
    public int maxFish = 10;
    public TextMeshProUGUI fishCaughtText;

    public int activeScene = 1; 

    // Start is called before the first frame update
    void Start()
    {
        SwitchToFishing();
    }

    // Update is called once per frame
    void Update()
    {
        //spawn more fish if there are less than 5 fish
        if ((activeScene == 1) && (fishCount <= 5))
        {
            spawnFish.SpawnObjects();
        }
        fishCaughtText.text = "Fish Caught: " + fishCaught;
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
