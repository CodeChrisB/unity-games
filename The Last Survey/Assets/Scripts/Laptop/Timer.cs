using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float TheTime = 60;
    private bool Run = false;
    private int Question;
    SurveyManager sm;

    private void Start()
    {
        GameObject obj = GameObject.Find("Laptop");
        sm = (SurveyManager)obj.GetComponent(typeof(SurveyManager));

    }

    private void Update()
    {
        if (Run)
        {

            TheTime -= Time.deltaTime;
            if (TheTime <= 0)
                sm.SetQuestion(Question);

            sm.BigText.SetText(TheTime.ToString());
        }
        
    }
    public void StartTimer(int seconds,int question)
    {
        sm.HideAllUI();
        sm.BigText.gameObject.SetActive(true);
        TheTime = seconds;
        Run = true;
        Question = question;
    }
    

}
