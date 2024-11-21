using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    public float speed;        // Speed of movement
    public float minX;       // Left boundary for movement
    public float maxX;        // Right boundary for movement

    private bool movingRight = true; // Direction of movement

    void Update()
    {
        // Move the fish
        if (movingRight)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            if (transform.position.x >= maxX)
                movingRight = false;
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            if (transform.position.x <= minX)
                movingRight = true;
        }
    }
}
