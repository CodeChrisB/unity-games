using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Something does not work no idea just no sfx for this game
    public static SoundManager manager;
    private AudioSource src;
    public AudioClip collectSound;

    void Start()
    {
        manager = this;
        src = GetComponent<AudioSource>();
      
    }

    public void PlayCoinSound()
    {
        src.PlayOneShot(collectSound);
    }
}
