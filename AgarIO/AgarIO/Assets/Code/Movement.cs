using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public int area = 50;
    public float speed
    {
        get { return (float)(moveSpeed / Math.Log(Eat.size/2+2)); }
        set { speed = value; }
    }



    // Update is called once per frame
    private bool isPositiveMovement;
    void Update()
    {

        
        var targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);


        targetPos.z = transform.position.z;
 
//
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
     }

}
