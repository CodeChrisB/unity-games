using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public bool IsVertical = true;
    public float Move = 0.2f;
    public float Time = 5;
    void Start()
    {
        if (IsVertical)
        {
            LeanTween.moveLocalY(gameObject, gameObject.transform.position.y + Move, Time).setLoopPingPong();
        }
        else
        {
            LeanTween.moveLocalX(gameObject, gameObject.transform.position.x + Move, Time).setLoopPingPong();
        }

    }


}
