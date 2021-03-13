using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{

    public GameObject arrow;
    public float launchForce;
    public Transform shotPoint;
    public float delay = 2f;
    private float currentDelay = 0f;






    // Update is called once per frame
    void Update()
    {
        Vector2 bowPosition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 directon = mousePosition - bowPosition;
        transform.right = directon;
        currentDelay = currentDelay > Time.deltaTime ? currentDelay - Time.deltaTime : 0f;

        if (Input.GetMouseButton(0) && currentDelay==0f) //left mouse button
        {
            Shoot();
        }


    }

    void Shoot()
    {
        GameObject newArrow = Instantiate(arrow, transform.position, transform.rotation);
        newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
        currentDelay = delay;
    }

}
