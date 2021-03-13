using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPill : MonoBehaviour
{
    public GameObject pill;
    public void Spawn()
    {
        pill.transform.position = new Vector3(7.71f, 11.78f, 10.04f);
        Instantiate(pill);
    }
}
