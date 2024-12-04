using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public GameManager gm;          // Reference to the GameManager for tracking fish count
    private GameObject currFish;    // Reference to the current fish caught by the hook
    public bool isFishing = false;  // Flag to check if the hook is fishing

    void Start()
    {
        isFishing = true;
    }

    void Update()
    {
        // Make the caught fish follow the hook's position
        if (currFish != null){
            Vector3 hookPosition = transform.position;
            currFish.transform.position = new Vector3(hookPosition.x, hookPosition.y, currFish.transform.position.z);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision detected!");
        //print(other.tag + isFishing + gm.fishCaught + gm.maxFish);
        

        // Check if the collided object has the tag "Fish"
        if (other.CompareTag("Fish") && isFishing == true && gm.fishCaught < gm.maxFish)
        {
            // Rotate the fish 90 degrees depending on its current facing direction
            Transform fishTransform = other.transform;
            Vector3 newRotation = fishTransform.eulerAngles + new Vector3(0, 0, 90);
            fishTransform.eulerAngles = newRotation;

            // Add the fish to the list of caught fish
            currFish = other.gameObject;

            // Disable the fish's collider to prevent multiple collisions
            currFish.GetComponent<Collider2D>().enabled = false;

            // Decrement the fish count in the GameManager
            gm.fishCount--;
            

            Debug.Log("Fish caught!");

            isFishing = false;
        }
        if (other.CompareTag("Boat") && isFishing == false)
        {
            gm.fishCaught++;
            gm.totalFishCaught++;
            gm.caughtFishTiers[gm.fishCaught - 1] = currFish.GetComponent<MergeFish>().GetFishTier();

            gm.score += currFish.GetComponent<MergeFish>().fish_tier;

            Destroy(currFish);

            // Set the fishing flag to false
            isFishing = true;

            Debug.Log("Fish released!");
            
        }
    }
}
