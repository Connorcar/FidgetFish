using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    public float speed;       // Speed of movement
    private float minX = 100;        // Left boundary for movement
    private float maxX = 1080;        // Right boundary for movement

    private bool movingRight = true; // Direction of movement

    private void Start()
    {
        // maxX = 960;
        // minX = -960;
        // random transform direction
        float randomFlip = Random.Range(0, 2);

        if ((randomFlip == 1) && (movingRight))
        {
            Debug.Log("flip");
            movingRight = false;
            FlipSprite();
        }
        
    }

    void Update()
    {
        // Move the fish
        if (movingRight)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            if (transform.position.x >= maxX)
            {
                movingRight = false;
                FlipSprite(); // Flip the sprite when hitting the right wall
            }
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            if (transform.position.x <= minX)
            {
                movingRight = true;
                FlipSprite(); // Flip the sprite when hitting the left wall
            }
        }
    }

    // Flips the sprite by inverting the local X-scale
    void FlipSprite()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1; // Invert the X-scale
        transform.localScale = localScale;
    }

    public void setSpeed(int newSpeed)
    {
        speed = newSpeed;
    }

    public void setx(float newMinX, float newMaxX)
    {
        minX = newMinX;
        maxX = newMaxX;
    }
}
