using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    // Start is called before the first frame update

    public bool isVertical = true;
    public float path;
    public float speed=2;



    Vector3 startPos;
    Vector3 endPos;
    Vector3 nextPos;

    void Start()
    {
        startPos = transform.position;
        endPos = transform.position;

        if (isVertical)
        {
            endPos.y = path;
        }
        else
        {
            endPos.x = path;
        }

        nextPos = endPos;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (isVertical)
        {
            if (transform.position.y == endPos.y)
                nextPos = startPos;
            if (transform.position.y == startPos.y)
                nextPos = endPos;
        }
        else
        {
            if (transform.position.x == endPos.x)
                nextPos = startPos;
            if (transform.position.x == startPos.x)
                nextPos = endPos;
        }


        transform.position = Vector2.MoveTowards(transform.position, nextPos, speed);



    }



}
