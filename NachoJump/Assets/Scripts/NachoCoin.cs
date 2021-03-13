using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class NachoCoin : MonoBehaviour
{

    public AudioSource audioSource;
    private float time;

    void Start()
    {
        time = ((Spawner)GameObject.Find("Spawner").GetComponent(typeof(Spawner))).Time;
        audioSource = GetComponent<AudioSource>();
        LeanTween.moveY(gameObject, gameObject.transform.position.y + 20, time).setDestroyOnComplete(true);
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
     if (other.transform.tag == "Player")
        {
            ((GameHandler)GameObject.Find("Spawner").GetComponent(typeof(GameHandler))).CountNacho();
            //SoundManager.manager.PlayCoinSound();
            Explode();
            Destroy(gameObject);

        }

    }

    void Explode()
    {
        //GameObject firework = Instantiate(FireworksAll, position, Quaternion.identity);
        //firework.GetComponent<ParticleSystem>().Play();
    }

}
