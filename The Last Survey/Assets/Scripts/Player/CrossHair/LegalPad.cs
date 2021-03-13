using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LegalPad : MonoBehaviour
{
    private PathManager pm;
    private SurveyManager sm;
    private int clicks = 0;
    public TMP_Text text;
    public string[] level;
    private void Start()
    {
        pm = (PathManager)GameObject.Find("PathManager").GetComponent(typeof(PathManager));
        sm = (SurveyManager)GameObject.Find("Laptop").GetComponent(typeof(SurveyManager));
        level = new string[5];
        level[0] = "Being stuck in traffic";
        level[1] = "Watching Tv adverts";
        level[2] = "Junk mail";
        level[3] = "Being on hold";
        level[4] = "This Survey";
    }
    private void OnMouseDown()
    {
        if (pm.Path == 1)
        {
            clicks++;
            if (clicks == 6)
            {
                sm.SetQuestion(39);
                SetRageText();
            }
            else
            {
                Debug.Log("Click on Legal Pad");
                SetText();
            }
        }
    }

    private void SetRageText()
    {
        text.text = "CAN YOU STOP\n WRITING ON NOTEPAD!\n----------------------------\nIT'S VERY DISRESPECTFUL\nTO DO OTHER THINGS\n----------------------------";
    }

    private void SetText()
    {
        text.text += $"{6-clicks} - {level[clicks-1]}\n";
    }
}
