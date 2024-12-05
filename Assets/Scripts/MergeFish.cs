using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MergeFish : MonoBehaviour
{
    public float size_multiplier = 1.5f;
    public int fish_tier = 1;
    public int maxFishTier = 10;

    private DragAndDrop dragAndDrop;
    private Aquarium aquarium;

    public AudioSource audioSource;

    private void Start()
    {
        // transform.localScale = new Vector3(-1f, 1f, 1f);

        dragAndDrop = GetComponent<DragAndDrop>();
        aquarium = FindObjectOfType<Aquarium>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Fish")
        {
            MergeFish collisionFish = collision.gameObject.GetComponent<MergeFish>();
            if ((fish_tier == collisionFish.fish_tier) && (fish_tier <= maxFishTier))
            {
                if (dragAndDrop.IsDragging() || collisionFish.dragAndDrop.IsDragging()) 
                {
                    if (gameObject.GetInstanceID() < collision.gameObject.GetInstanceID())
                    {
                        audioSource.Play();
                        StartCoroutine(SpawnNewFish());
                    }
                    else
                    {
                        Destroy(gameObject);
                    }
                }
            }
        }
    }

    private IEnumerator SpawnNewFish()
    {
        GameObject newFish = Instantiate(aquarium.fishPrefabs[fish_tier], this.transform.position, Quaternion.identity, aquarium.fishParent);

        GetComponent<Image>().enabled = false;
        yield return new WaitForSeconds(1);

        Destroy(this.gameObject);
    }

    public int GetFishTier()
    {
        return fish_tier;
    }
}
