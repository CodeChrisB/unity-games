using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CrateDestroy : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D collision)
    {//Detecting the Grid Position of Playerd
        if (collision.gameObject.tag == "Arrow")
        {
            Destruct(collision.gameObject);
        }

    }

    private void Destruct(GameObject collision)
    {
        Destroy(this.gameObject);
        Destroy(collision);
    }

}
