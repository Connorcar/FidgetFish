using UnityEngine;

public class SyncObject : MonoBehaviour
{
    public RectTransform objectUI; // The hook in the UI canvas
    public Transform objectWorld; // The hook in the world space
    public Camera mainCamera;   // The main camera rendering the world

    void Update()
    {
        // Convert the hook's UI position to world space
        Vector3 screenPos = RectTransformUtility.WorldToScreenPoint(null, objectUI.position);
        Vector3 worldPos = mainCamera.ScreenToWorldPoint(screenPos);
        worldPos.z = 0; // Ensure it's on the 2D plane
        // worldPos.y = worldPos.y + 960; // Adjust the Y position to match the world space
        // worldPos.x = worldPos.x + 540; // Adjust the X position to match the world space

        // Update the world hook's position
        objectWorld.position = worldPos;
    }
}
