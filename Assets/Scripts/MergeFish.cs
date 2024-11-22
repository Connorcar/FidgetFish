using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeFish : MonoBehaviour
{
    public float size_multiplier = 1.5f;
    public int fish_tier = 1;

    private void Start()
    {
        transform.localScale = new Vector3(-1f, 1f, 1f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (fish_tier == collision.gameObject.GetComponent<MergeFish>().fish_tier)
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
