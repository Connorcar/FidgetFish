using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    Vector3 pos;
    public float speed = 1f;
    public RectTransform hook;
    public RectTransform boat;
    public RectTransform line;
    public float minY = -480f; 
    public float maxY = 350f;
    public Vector2 boatFrontOffset;
    // Start is called before the first frame update
    void Start()
    {
        hook.anchoredPosition = new Vector2(0, 350);
    }

    // Update is called once per frame
    void Update()
    {        
        // Get the mouse position in screen coordinates
        Vector3 mousePosition = Input.mousePosition;

        // Clamp the Y position to stay within the specified range
        float clampedY = Mathf.Clamp(mousePosition.y, minY, maxY);

        // Set the hook's position, maintaining its current X position
        hook.anchoredPosition = new Vector2(hook.anchoredPosition.x, clampedY);

        // Calculate the position of the front of the boat
        Vector2 boatFrontPos = boat.anchoredPosition + boatFrontOffset;

        // Get the position of the hook
        Vector2 hookPos = hook.anchoredPosition;

        // Calculate the distance between the boat's front and the hook
        float distance = boatFrontPos.y - hookPos.y;

        // Update the line's position and size
        line.anchoredPosition = new Vector2(boatFrontPos.x, boatFrontPos.y - distance / 2); // Midpoint
        line.sizeDelta = new Vector2(line.sizeDelta.x, Mathf.Abs(distance));
    }
}
