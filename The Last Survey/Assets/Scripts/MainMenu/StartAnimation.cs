﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        LeanTween.moveZ(gameObject, 0.5f, 100f).setDestroyOnComplete(true);
    }

}
