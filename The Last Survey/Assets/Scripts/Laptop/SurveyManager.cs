using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Linq;
using TMPro;
using System.Threading;
using UnityEngine.UI;

public class SurveyManager : MonoBehaviour
{
//Buttons
    //Left
    public GameObject Left;
    public TMP_Text LeftText;
    //Right
    public GameObject Right;
    public TMP_Text RightText;
    //DownLeft
    public GameObject DownLeft;
    public TMP_Text DownLeftText;
    //DownRight
    public GameObject DownRight;
    public TMP_Text DownRightText;
    //Big Button
    public GameObject BigButton;
    public TMP_Text BigButtonText;
    //Loop Able Button Array
    public FullButton[] Buttons = new FullButton[4];
//Other
    //Text Only
    public TMP_Text TopText;
    public TMP_Text BigText;
    //The csv
    public TextAsset textCSV;
    //Question List
    public List<Question> questions = new List<Question>();
    //the current question
    Question current = null;
    //the id of the next question
//Spawn Objects
    int nextId;
    WorldSpawner ws;
    Timer tr;
    PathManager pm;
    private GameObject animationButton;
    public LeanTweenType type;
    public int CurrentPath { get; private set; }
    void Start()
    {

        GameObject obj = GameObject.Find("WorldSpawner");
        ws= (WorldSpawner)obj.GetComponent(typeof(WorldSpawner));
        ws.OpenMainDoor();
        obj = GameObject.Find("Laptop");
        tr = (Timer)obj.GetComponent(typeof(Timer));

        obj = GameObject.Find("Laptop");
        tr = (Timer)obj.GetComponent(typeof(Timer));

        obj = GameObject.Find("PathManager");
        pm = (PathManager)obj.GetComponent(typeof(PathManager));

        questions = readCSV();
        initFullButtons();
    }
    private void initFullButtons()
    {
        Buttons[0] = new FullButton(Left, LeftText);
        Buttons[1] = new FullButton(Right,RightText);
        Buttons[2] = new FullButton(DownLeft, DownLeftText);
        Buttons[3] = new FullButton(DownRight, DownRightText);
    }
    List<Question> readCSV()
    {
        List<Question> q = new List<Question>();

        string text = "1,0,Do you want to start the Survey ?,Yes,2_2,0,Are you 18+ Years old ?,Yes,3,No,3_3,1,Are you Inside your own room ?,Yes,4,No,5_4,1,Do you like your Room ?,Yes,6,No,6_5,1,Do you know where you are ?,Yes,4,No,12_6,1,Do you like animals ?,Yes,7,No,7_7,1,Would you say you are more intelligent than the average person ?,Yes,8,No,8_8,1,How much money do you spend on food each month?,Yes,9,No,9_9,1,Are you a vegetarian ?,Yes,10,No,10,I try to eat less meat,10,I only eat meat,10_10,1,Who draw the Mona Lisa ?,Leonardo di Caprio,11,Spongebob,11,A chinese artist,11,We do not know who draw it,11_11,1,Will computers be able to feel love someday ?,Yes,1001,No,1001_12,2,Are you alone ?,Yes,54,No,13_13,2,Is this living being friendly ?,Yes,55,No,14_14,2,Does this living being try to harm you ?,Yes,15,No,16_15,2,Would a weapon help you in this situation ?, Yes,507,No,18_16,2,Do you like the living being ?,Yes,17,No,17_17,2,Are you sure ?,Yes,1009,No,1009_18,2,Have you ever taken drugs ?, Yes,19,No,19_19,2,Would you like to take some ?,Yes,501,No,1009_20,0,Would you rather like to play a game ?,Yes,21,No,56_21,4,I changed something in your room find click on it or you die._22,5,Do you feel better after drinking your coffee ?,Yes,23,No,24_23,5,Can we start now ?,Yes,2,No,28_24,5,Maybe one more coffee ?,Yes,504,No,25_25,5,Can we start now ?,No,26,Yes,503_26,5,Would you answer my survey after one more coffee,Yes,502,No,27_27,5,So do you want a lot of coffee ?,Yes,1005,No,503_28,5,Are you scared of the survey ?,Yes,29,No,25_29,6,Would an image of my cat help you relax ?,Yes,505,No,57_30,6,Are you relaxed now ?,Yes,503,No,506_31,6,After starring at my cat for 60 Seconds you have to be so relaxed,Yes i am relaxed,32,No your cat did not help,33_32,6, Can we finally start with the survey ?,Yes,504,No,34_33,6,Are you saying my cat is not relaxing ?,Yes,508,No,32_34,6,Are you saying my cat did not help you relax enough?,Yes,508,No,35_35,6,Isn't my cat the cutest being alive ?,Yes your cat is the cutest thing alive,1004,No I am a bad person,38_36,6,Do you still think my cat is not relaxing ?,Yes,37,No,38_37,6,Would u be willing to have your mind changed ?,Yes,1004,No,503_38,6,Can more images of my cat can you make you change your mind ?,Yes,1003,No,503_39,7,Are you sorry for interrupting my survey ?,Yes,40,No,59_40,7,How was my survey so far ?,It was the best survey I ever did,41_41,7,But why did you play with that legal pad ?,I have not said that,42,I dont know,43_42,7,Why are you lying to me?,Im sorry for lying to you,1002,Because you are a computer,43_43,7,I want a real answer,My brother came into my room and clicked on the legal pad!,1002,The questions were to easy,1002_44,4,Hey could you please stop playing with the Lamp ?,Yes,509_45,4,Do you want to do a survey about desk lamps ?,Yes,46,No,45_46,4,What is your favourite desk lamp,Swing Arm,47,Mid Century Modern,47,Tiffany,47,Banker's Lamp's,47_47,4,What is your favourite light bulb ?,Compact Fluorscent,48,LED's,48,Xenon,48,Halogen,48_48,4,What should a desk lamp be made out of ?,Metal,49,Plastic,49,Wood,49,Ceramic,49_49,4,How much would you pay for a good desklamp ?,25$-50$,50,50$-100$,50,100$-200$,50,More than 200$,50_50,4,What is more important to you ?,Love,52,A good Lamp,51_51,4,Do you love a good lamp more than your own mother?,Yes,60,No,52_52,4,Then you should text your mother,Sure_56,0,Would you like to start the Survey ?,Yes,2_57,6,Do you have something against cats ?,Yes,1011,No,58_58,6,So would you want to see my cat now?,Yes,505,Yes,505,Yes,505,Yes,505_59,7,Wrong Answer,I understand,39_60,4,Press the lamp 500 times for a suprise,Yes,510";
        string[] lines = text.Split('_');
        foreach (string line in lines)
        {
            //Debug.Log(line);
            string[] data = line.Split(',');

            Question question = new Question(int.Parse(data[0]), int.Parse(data[1]), data[2]);

            for (int i = 3; i + 1 < data.Length; i += 2)
            {
                question.Anwsers.Add(new Answer(data[i] , int.Parse(data[i + 1])));
            }
            q.Add(question);
        }

        return q;

    }
    public void Pressed(Enum type)
    {
        int i = Convert.ToInt32(type);
        if (i == Convert.ToInt32(ButtonType.BigButton))
            i = Convert.ToInt32(ButtonType.Left);
        if (current ==  null)
        {
            //the game needs to be started
            nextId = 1;
            SetQuestion();

        }
        else
        {
                nextId = current.Anwsers[i].Next;
                SetQuestion();
        }
    }

    #region Question
    public void SetQuestion()
    {
        //remove everything from ui 
        HideAllUI();
        //now show everything that needs to be shown
        //get next question

        if (nextId > 500)
        {
            EventTrigger();
        }
        else
        {
            current = questions.Where(question => question.Id == nextId).FirstOrDefault();
            //Set Data for Path Manager
            pm.SetQuestion(current); 
            TopText.text = current.Title;
            TopText.gameObject.SetActive(true);
            SetButtons(current);
        }
    }

    public void SetQuestion(int id)
    {
        nextId = id;
        SetQuestion();
    }

    private void SetButtons(Question nextOne)
    {

        int buttonCount = nextOne.Anwsers.Count();
        if (current.Anwsers.Count > 1)
        {
            for (int i = 0; i < buttonCount; i++)
            {                
                Buttons[i].Text.SetText(nextOne.Anwsers[i].Text);
                Buttons[i].Button.SetActive(true);
                //LeanTween.scale(Buttons[i].Button, new Vector3(0, 0, 0), 3f).setEase(type);
            }
        }
        else
        {
            BigButton.SetActive(true);
            BigButtonText.SetText(nextOne.Anwsers[0].Text);
            //LeanTween.scale(BigButton, new Vector3(0, 0, 0), 3f).setEase(type);
        }

    }



    public void HideAllUI()
    {
        Left.SetActive(false);
        Right.SetActive(false);
        DownLeft.SetActive(false);
        DownRight.SetActive(false);
        BigButton.SetActive(false);
        TopText.gameObject.SetActive(false);
        BigText.gameObject.SetActive(false);
    }

    #endregion

    #region Trigger
    private void EventTrigger()
    {
        if (nextId > 1000)
        {
            Debug.Log("Ending Reached with the Id " + nextId);
            switch (nextId)
            {
                case 1001:
                    ThankYou();
                    break;
                case 1002:
                    SurveyInterruptor();
                    break;
                case 1003:
                    SpawnLotsOfCatsImages();
                    break;
                case 1004:
                    SpawnLotsOfCats();
                    break;
                case 1005:
                    SpawnALotOfCoffee();
                    break;
                case 1006:
                    break;
                case 1007:
                    break;
                case 1008:
                    Electrocution();
                    break;
                case 1009:
                    NewsPaper();
                    break;
                case 1010:
                    HappyEnd();
                    break;
            }
        }
        else
        {
            switch (nextId)
            {
                case 501:
                    ws.SpawnPill();
                    break;
                case 502:
                    ws.FillCoffee(); 
                    break;
                case 503:
                    ResetFromCoffee();
                    break;
                case 504:
                    ws.FillCoffee();
                    ws.ResetAfterNextCoffee();
                    break;
                case 505:
                    SpawnCatImage();
                    break;
                case 506:
                    ForceLookAtCat(); //does not work
                    break;
                case 507:
                    SpawnBanana();
                    break;
                case 508:
                    SpawnCat();
                    break;
                case 509:
                    ResetFromLamp();
                    break;
                case 510:
                    LampClickGame();
                    break;
            }
        }
    }

    private void HappyEnd()
    {
        throw new NotImplementedException();
    }

    private void Electrocution()
    {
        throw new NotImplementedException();
    }

    private void LampClickGame()
    {
        HideAllUI();
        BigText.gameObject.SetActive(true);
        ws.LampGame();
    }

    private void ResetFromLamp()
    {
        ws.RemoveLamp();
        SetQuestion(1);
    }

    private void SurveyInterruptor()
    {
        Debug.Log("Survey Interruptor");
        throw new NotImplementedException();
    }

    private void SpawnLotsOfCatsImages()
    {
        ws.SpawnLotsOfImages();
    }

    private void SpawnLotsOfCats()
    {
        ws.SpawnLotsOfCat();
    }

    #endregion

    public void SetBigText(string text)
    {
        TopText.gameObject.SetActive(true);
        TopText.SetText(text);
    }

    private void SpawnCat()
    {
        ws.SpawnCat();
        SetQuestion(36);
    }

    private void SpawnBanana()
    {
        ws.SpawnBanana();
        SetQuestion(18);
    }

    private void ForceLookAtCat()
    {

        ws.ForceCat(); //forces to look at the cat cant move mouse
        //Timer(10);//make a timer 
        Debug.Log("10 Seconds over");
        //tr.StartTimer(60, 31);
        //HideAllUI();
        SetQuestion(31);

        
    }

    private void FreeFromCat()
    {

    }
    

    private void SpawnCatImage()
    {
        ws.SpawnCatImage();
        SetQuestion(30);
    }

    private void ResetFromCoffee()
    {
        SetQuestion(1);
        ws.DestroyCoffe();
    }


    #region Endings
    //When you do the survey without annoying the computer
    private void ThankYou()
    {
        HideAllUI();
        BigText.gameObject.SetActive(true);
        BigText.text = "Thank you for taking your time for the Survey";
    }
    //when you say you like the living being or dont want to take drugs
    private void NewsPaper()
    {
        HideAllUI();
        BigText.gameObject.SetActive(true);
        BigText.text = "Show A newspaper with the death of the character as headline";
    }

    //when you annoy the coputer with your coffee addiction
    private void SpawnALotOfCoffee()
    {
        float startX= 16f; 
        float startY = 10.76f;
        float startZ = 17f;
            for (int i = 0; i < 46; i++)
            {
                for (int j = 0; j < 41; j++)
                {

                    ws.SpawnCoffe(new Vector3(
                        startX - 0.2f * i,
                        startY,
                        startZ - 0.2f * j
                        ));

                }
            }

     
            ws.SpawnCoffe(new Vector3(
            11,
            10.5f,
            12
            ), 8);



        BigText.SetText("Turn Around", true);
        BigText.gameObject.SetActive(true);
    }

    #endregion

    public void TriggerEvent(int id)
    {
        nextId = id;
        EventTrigger();
    }

}

