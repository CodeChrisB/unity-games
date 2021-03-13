using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonClick : MonoBehaviour
{

    public GameObject Laptop;
    public ButtonType type;
    private void OnMouseDown()
    {
        Laptop.GetComponent<SurveyManager>().Pressed(type);
    }
}
