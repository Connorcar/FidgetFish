using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision detected!");
        // Check if the collided object has the tag "Fish"
        if (other.CompareTag("Fish"))
        {
            // Destroy the fish GameObject
            Destroy(other.gameObject);

            // (Optional) You can add additional logic here, e.g., score increment
            Debug.Log("Fish caught!");
        }
    }
}
