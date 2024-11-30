using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeFish : MonoBehaviour
{
    public float size_multiplier = 1.5f;
    public int fish_tier = 1;

    private DragAndDrop dragAndDrop;

    private void Start()
    {
        transform.localScale = new Vector3(-1f, 1f, 1f);

        dragAndDrop = GetComponent<DragAndDrop>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        MergeFish collisionFish = collision.gameObject.GetComponent<MergeFish>();
        if (fish_tier == collisionFish.fish_tier)
        {
            if (dragAndDrop.IsDragging() || collisionFish.dragAndDrop.IsDragging()) 
            {
                if (gameObject.GetInstanceID() < collision.gameObject.GetInstanceID())
                {
                    Destroy(collision.gameObject);
                    gameObject.transform.localScale = gameObject.transform.localScale * size_multiplier;
                    fish_tier += 1;
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
