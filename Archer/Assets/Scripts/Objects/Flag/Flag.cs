using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{

    public int level;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Beaten Level " + level);
        if (collision.gameObject.tag == "Player")
        {
            LevelManager.BeatenLevel(level);
            LevelManager.LoadNextLevel();
        }
    }
}
