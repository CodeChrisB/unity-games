using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public  Transform spawnPos;
    public  GameObject spawnee;
    public float speed = 0.75f;
    public float spawnRadius = 0f;
    /*public*/float spawnCircle = 1.2f;
  
    // Start is called before the first frame update
    void Start()
    {
        //start in 0 seconds call spawn bubble every second
        InvokeRepeating("SpawnBubble", 0f, speed);
    }

    public void SpawnBubble()
    {
        int rotation = Random.Range(0, 360);
        Vector3 pos = spawnPos.position;
        pos.x += Mathf.Sin(rotation)*spawnCircle*(1+Random.Range(0f,spawnRadius));
        pos.y += Mathf.Cos(rotation) * spawnCircle * (1+Random.Range(0f, spawnRadius));



        Debug.Log("Spawn");
        GameObject bubble = Instantiate(spawnee, pos, spawnPos.rotation);
        bubble.GetComponent<SpriteRenderer>().color = RandomColor();
    }

    private Color RandomColor()
    {
        return new Color(
         Random.Range(0f, 1f),
         Random.Range(0f, 1f),
         Random.Range(0f, 1f)
        );
    }

    // Update is called once per frame
    void Update()
    {
     
    }
}
