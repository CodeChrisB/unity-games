using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
 
    private Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        //get the current camera
        Vector3 newCamera = transform.position;

        //set camera to player
        newCamera.x = player.position.x;
        newCamera.y = player.position.y;

        //update camera
        transform.position = newCamera;
    }
}
