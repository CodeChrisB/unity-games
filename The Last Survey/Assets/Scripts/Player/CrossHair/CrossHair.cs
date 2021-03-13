using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHair : MonoBehaviour
{
    public Texture2D crossHairImage;
    void Start()
    {
        
    }
  
    void Update()
    {
     
    }

    void OnGUI()
    {
        float xMin = (Screen.width / 2) -(crossHairImage.width/2);
        float yMin = (Screen.height / 2) - (crossHairImage.height / 2);

        GUI.DrawTexture(new Rect(xMin, yMin, crossHairImage.width, crossHairImage.height),crossHairImage);
    }
}
