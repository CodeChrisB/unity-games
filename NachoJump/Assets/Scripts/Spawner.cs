using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Nacho;
    public GameObject BadNacho;
    public GameObject BadNacho2;
    public GameObject[] obstacles;
    private float time = 6;
    private int obstacleSpawn = 5;



    public float Time
    {
        get { return time; }
        private set
        {
            time = (time - value) > 2f ? (time - value) : 2f;
        }
    }


    int badCounter = 0;
    public bool isAlive;
    public void StartGame()
    {
        LeanTween.delayedCall(Random.Range(0.5f, 1f),SpawnNacho);
        LeanTween.delayedCall(Random.Range(2.9f, 3f),SpawnBadNacho);
        LeanTween.delayedCall(10f,SpawnObstacle);

    }

    private void SpawnObstacle()
    {
       Vector3 pos = new Vector3(0, -8.5f, 1f);
        Instantiate(obstacles[Random.Range(0, obstacles.Length)], pos, Quaternion.identity);

        LeanTween.delayedCall(((10 - 0.5f * badCounter)>4f ? (10 - 0.5f * badCounter):4f), SpawnObstacle);
        badCounter++; ;
        //make game harder
        Time -= 0.05f;

    }

    private void SpawnNacho()
   {
       if (!isAlive) //dead nacho wont get more nachos
            return;

        Vector3 pos = new Vector3(Random.Range(-8.5f, 3.8f), -4.5f, 1f);
        GameObject go = Instantiate(Nacho, pos,Quaternion.identity);
        LeanTween.delayedCall(Random.Range(0.1f, 0.7f), SpawnNacho);
        go.transform.parent = this.transform;
    }

    private void SpawnBadNacho()
    {
        if (!isAlive) //dead nacho wont get more nachos
            return;

       Vector3 pos = new Vector3(Random.Range(-8.5f, 3.8f), -4.5f, 1f);
       Instantiate(BadNacho, pos, Quaternion.identity);
       LeanTween.delayedCall(Random.Range(2f, 4f), SpawnBadNacho);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
