using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    Button[] LevelButtons;
    private static int currentLevel;
    //this integer should not be public since we do not want any
    //other script to be able to change it.
    private static int ReachedLevel = 1;
    private void Awake()
    {
        SetButtons();
    }

    private  void SetButtons()
    {
        LevelButtons = new Button[transform.childCount];
        for (int i = 0; i < LevelButtons.Length; i++)
        {
            Debug.Log(ReachedLevel);
            LevelButtons[i] = transform.GetChild(i).GetComponent<Button>();
            LevelButtons[i].GetComponentInChildren<Text>().text = (i + 1).ToString();
            Debug.Log(i+""+(i + 1 > ReachedLevel));
            if (i + 1 > ReachedLevel)
            {
                LevelButtons[i].interactable = false;
            }
            else
            {
                LevelButtons[i].interactable = true;
            }
        }
    }

    public static void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
        currentLevel = level;
    }

    public static void LoadNextLevel()
    {
        LoadLevel(ReachedLevel + 1);
        currentLevel = ReachedLevel + 1;
    }

    public static void BeatenLevel(int level)
    {
        ReachedLevel = Mathf.Max(level, ReachedLevel);
    }

    public static void Resetlevel()
    {
        SceneManager.LoadScene(currentLevel);
    }

    public void LoadLevelNormal(int level)
    {
        LoadLevel(level);
    }
}
