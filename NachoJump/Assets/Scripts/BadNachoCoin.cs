using System;
using UnityEngine;


public class BadNachoCoin : MonoBehaviour
{

    public AudioSource audioSource;
    public bool xMovement = true;
    private float time;



    void Start()
    {
        time = ((Spawner)GameObject.Find("Spawner").GetComponent(typeof(Spawner))).Time;
        audioSource = GetComponent<AudioSource>();
        LeanTween.moveY(gameObject, gameObject.transform.position.y + 20, time*1.5f).setDestroyOnComplete(true);
        if(xMovement)
        LeanTween.moveX(gameObject, gameObject.transform.position.x + UnityEngine.Random.Range(2f, 8f), 0.5f).setLoopPingPong();
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Player")
        {
            ((GameHandler)GameObject.Find("Spawner").GetComponent(typeof(GameHandler))).RemoveNacho();
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
