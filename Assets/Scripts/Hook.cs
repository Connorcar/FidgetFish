using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public GameManager gm;          // Reference to the GameManager for tracking fish count
    private List<GameObject> caughtFish = new List<GameObject>(); // List to track caught fish
    public bool isFishing = false;  // Flag to check if the hook is fishing

    void Update()
    {
        // Make the caught fish follow the hook's position
        foreach (GameObject fish in caughtFish)
        {
            if (fish != null)
            {
                Vector3 hookPosition = transform.position;
                fish.transform.position = new Vector3(hookPosition.x, hookPosition.y, fish.transform.position.z);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision detected!");

        // Check if the collided object has the tag "Fish"
        if (other.CompareTag("Fish"))
        {
            // Rotate the fish 90 degrees depending on its current facing direction
            Transform fishTransform = other.transform;
            Vector3 newRotation = fishTransform.eulerAngles + new Vector3(0, 0, 90);
            fishTransform.eulerAngles = newRotation;

            // Add the fish to the list of caught fish
            caughtFish.Add(other.gameObject);

            // Disable the fish's collider to prevent multiple collisions
            other.GetComponent<Collider2D>().enabled = false;

            // Decrement the fish count in the GameManager
            gm.fishCount--;

            Debug.Log("Fish caught!");
        }
    }
}
