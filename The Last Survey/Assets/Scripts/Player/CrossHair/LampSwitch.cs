using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampSwitch : MonoBehaviour
{

    int clicked = 0;

    public Light point;
    public Light spot;
    public int StoryClicks = 10;
    public int LampGameClick = 20;
    bool isLightOn = true;
    bool inLampGameLoop = false;
    SurveyManager sm;
    PathManager pm;
    private void Start()
    {
        sm = (SurveyManager)GameObject.Find("Laptop").GetComponent(typeof(SurveyManager));
        pm = (PathManager)GameObject.Find("PathManager").GetComponent(typeof(PathManager));
    }
    private void OnMouseDown()
    {
        //Switch Lamp on off

        Debug.Log("Clicked");
        isLightOn = !isLightOn;
        point.intensity = isLightOn ? 2f : 0;
        spot.intensity = isLightOn ? 1.4f : 0;
        clicked++;
        if (!inLampGameLoop)
        {
            if (clicked == StoryClicks)
            {
                sm.SetQuestion(44);
            }
            else if (pm.QuestionId == 44)
            {
                sm.SetQuestion(45);
            }
        }
        else
        {
            //Lamp Game
            string text = (LampGameClick - clicked).ToString();
            sm.SetBigText(text);
            if (LampGameClick - clicked == 0)
            {
                sm.TriggerEvent(1008);
            }
        }
       

    }

    public void Remove()
    {
        Destroy(gameObject); 
    }

    internal void lampGame()
    {
        clicked = 0;
        inLampGameLoop = true;
    }
}
