using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //get the current camera
        Vector3 newCamera = transform.position;

        //set camera to player
        newCamera.x = player.position.x;
        newCamera.y = player.position.y+1;

        //update camera
        transform.position = newCamera;
    }
}
