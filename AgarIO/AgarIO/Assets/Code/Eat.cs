using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Eat : MonoBehaviour
{
    public float lifeTime = 500f;
    static GameObject player;
    public static float size = 1.5f;
    public static float factor = 1.0001f;





    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        setSize();
    }



    void Update()
    {
        if (lifeTime > 0)
        {
            lifeTime -= Time.deltaTime;
            if (lifeTime <= 0)
                Desctruction();
        }
    }



    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "Player")
            EatBubble(coll);
    }

    private void EatBubble(Collision2D coll)
    {
        size = size + 1;
        Desctruction();
        setSize();
    }

    private void setSize()
    {
        //this fucntion needs more fine tunning
        float area = (float)( 2 * (size/10) * Math.PI);
        float newArea = area +factor;
        float radius = (float)(Math.Sqrt(area*0.5 /(float)Math.PI)/Math.PI);
        player.transform.localScale = new Vector3(radius, radius, 0);
    }


    private void Desctruction()
    {
        Destroy(this.gameObject);
    }
}
