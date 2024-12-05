using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAudio : MonoBehaviour
{
    public AudioClip aquarium_loop;
    public AudioClip ocean_loop;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        PlayOcean();
    }

    public void PlayOcean()
    {
        audioSource.Stop();
        audioSource.clip = ocean_loop;
        audioSource.Play();
    }

    public void PlayAquarium()
    {
        audioSource.Stop();
        audioSource.clip = aquarium_loop;
        audioSource.Play();
    }
}
