using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour
{
    private Canvas canvas;
    [SerializeField] private bool isDragging = false;

    private void Start()
    {
        canvas = GetComponentInParent<Canvas>();
    }

    public void DragHandler(BaseEventData data)
    {
        isDragging = true;

        PointerEventData pointerData = (PointerEventData)data;

        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            (RectTransform)canvas.transform,
            pointerData.position,
            canvas.worldCamera,
            out position);

        transform.position = canvas.transform.TransformPoint(position);
    }

    public void OnPointerDown(BaseEventData eventData)
    {
        isDragging = true;
    }

    public void OnPointerUp(BaseEventData eventData)
    {
        isDragging = false;
    }

    public bool IsDragging()
    {
        return isDragging;
    }
}
