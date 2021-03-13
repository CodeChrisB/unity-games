using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal") ;
        float y = Input.GetAxisRaw("Vertical");

        this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(x, y, -1), speed);
    }
}
