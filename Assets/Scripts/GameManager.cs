using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject FishingCanvas;
    public GameObject AquariumCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchToAquarium()
    {
        FishingCanvas.SetActive(false);
        AquariumCanvas.SetActive(true);
    }

    public void SwitchToFishing()
    {
        FishingCanvas.SetActive(true);
        AquariumCanvas.SetActive(false);
    }
}
