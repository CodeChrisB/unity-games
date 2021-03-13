using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pill : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log("Good Ending");
        Destroy(this.gameObject);
        ((WorldSpawner)GameObject.Find("WorldSpawner").GetComponent(typeof(WorldSpawner))).OpenMainDoor();

    }
}
