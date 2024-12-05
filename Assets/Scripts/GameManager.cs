using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject FishingCanvas;
    public GameObject AquariumCanvas;
    public GameObject MainMenuCanvas;
    public GameObject TutorialPanel;
    public Hook hook;
    public int fishCount = 0;
    public SpawnFish spawnFish;
    public int fishCaught = 0;
    public int[] caughtFishTiers;
    public int maxFish = 10;

    public BackgroundAudio backgroundAudio;

    public TextMeshProUGUI fishCaughtText;
    public TextMeshProUGUI totalFishCaughtText;
    public TextMeshProUGUI scoreText;

    public int totalFishCaught = 0;
    public int score = 0;

    public int activeScene = 1; 

    // Start is called before the first frame update
    void Start()
    {
        switchToMainMenu();

        caughtFishTiers = new int[maxFish];

        totalFishCaught = 0;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //spawn more fish if there are less than 5 fish
        if ((activeScene == 1) && (fishCount <= 5))
        {
            spawnFish.SpawnObjects();
        }
        fishCaughtText.text = "Fish Caught: " + fishCaught + "/" + maxFish;
        totalFishCaughtText.text = "Total Fish Caught: " + totalFishCaught;
        scoreText.text = "Score: " + score;
    }

    public void SwitchToAquarium()
    {
        FishingCanvas.SetActive(false);
        AquariumCanvas.SetActive(true);

        activeScene = 2;

        backgroundAudio.PlayAquarium();
    }

    public void SwitchToFishing()
    {
        FishingCanvas.SetActive(true);
        AquariumCanvas.SetActive(false);
        MainMenuCanvas.SetActive(false);

        activeScene = 1;
        hook.isFishing = true;

        backgroundAudio.PlayOcean();    
    }

    public void switchToMainMenu()
    {
        MainMenuCanvas.SetActive(true);
        AquariumCanvas.SetActive(false);
        FishingCanvas.SetActive(false);

        activeScene = 0;
    }

    public void switchToTutorial()
    {
        TutorialPanel.SetActive(true);
    }

    public void closeTutorial()
    {
        TutorialPanel.SetActive(false);
    }
}
