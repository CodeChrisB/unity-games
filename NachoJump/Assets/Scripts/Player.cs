using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int speed = 10;
    public bool canMove = false;
    void Update()
    {
        Move();   
    }

    public void Move()
    {

        if (!canMove)
            return;

        Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"), 0,0);
        gameObject.transform.position += Movement * speed * Time.deltaTime;
        //Keep the tasty nacho on the screen
        if (gameObject.transform.position.x < -9.5) {
            Vector3 pos = gameObject.transform.position;
                pos.x = -9.5f;
            gameObject.transform.position = pos;
        }
        else if (gameObject.transform.position.x > 6.4)
        {
            Vector3 pos = gameObject.transform.position;
            pos.x = 6.4f;
            gameObject.transform.position = pos;
        }
    }
}
