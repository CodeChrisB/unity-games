using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LeanTween.delayedCall(5f, DestroyNow);
    }

    private void DestroyNow()
    {
        if(gameObject!=null)
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
