using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffee : MonoBehaviour
{
    public GameObject CoffeeLevel;
    private bool coffee = true;
    private int consumedCoffees = 0;
    private bool resetOnNextClick = false;
    SurveyManager sm;
    private void OnMouseDown()
    {
        Debug.Log("Clicked");

        if (resetOnNextClick)
        {
            sm.SetQuestion(1);
            Destroy(this.gameObject);
        }
        else
        {
            SetCoffe(false);
            consumedCoffees++;

            if (consumedCoffees == 1)
            {
                GameObject obj = GameObject.Find("Laptop");
                sm = (SurveyManager)obj.GetComponent(typeof(SurveyManager));
                sm.SetQuestion(22);
            }
            if (consumedCoffees == 2)
            {
                sm.SetQuestion(25);
            }
        }
    }

    private void SetCoffe(bool set)
    {
        coffee = set;
        CoffeeLevel.SetActive(set);
    }

    public void FillCoffee()
    {
        SetCoffe(true);
    }

    public void ResetOnNextClick() => resetOnNextClick = true;
    public void DestroyCoffe() => Destroy(this.gameObject);
}
