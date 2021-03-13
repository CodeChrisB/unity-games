using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private TMP_Text scoreText;
    [SerializeField]
    private TMP_Text endScoreText;
    [SerializeField]
    public TMP_Text Quotes;
    public GameObject scoreDisplay;
    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;
    public GameObject Player;

    private double score = 0;

    public double Score
    {
        get { return score; }
    }

    private int lives = 3;
    public GameObject Scenery;
    public GameObject Bowl;
    private bool FallScore = false;
    void Start()
    {
        
    }

    private float nextActionTime = 0.0f;
    public float period = 0.1f;

    void Update()
    {
        if (!FallScore)
            return;

        if (Time.time > nextActionTime)
        {
            //give meaning less points to player to make him 
            //feel better :D
            nextActionTime += period;
            score++;
            SetScoreText();

        }
    }

    private void SetScoreText()
    {
        scoreText.SetText(score.ToString());
    }


    internal void StartFallScore() => FallScore = true;
    public void CountNacho()
    {
        score += 25;
        SetScoreText();
    }

    internal void RemoveNacho()
    {

        lives--;

        if (lives == 2)
        {
            Destroy(Heart3);
        }
        else if (lives == 1)
        {
            Destroy(Heart2);
        }
        else if (lives==0)
        {
            Destroy(Heart1);
        }

        if (lives<=0)
        {
            //set player
            Player player = ((Player)GameObject.Find("Player").GetComponent(typeof(Player)));
            player.canMove = false;
            player.transform.parent = Bowl.transform;

            //do dead stuff
            Vector3 t = Player.transform.position;
            t.z = 0;
            Player.transform.position = t;
            LeanTween.rotateZ(Player, +1080f, 1f);
            LeanTween.move(Player, new Vector3(-1f, -2f, 0f), 1f);


            //set game
            Spawner spawner = ((Spawner)GameObject.Find("Spawner").GetComponent(typeof(Spawner)));
            spawner.isAlive = false;

            LeanTween.delayedCall(2f, EndGame());
        }
        else 
        {
            return; 
        }


    }

    private Action EndGame()
    {
        
        LeanTween.move(Scenery,new Vector3(1.37f,10.9f,-1f),1f);
        LeanTween.delayedCall(2f, ShowEndUI);
        scoreDisplay.SetActive(false);
        Quotes.SetText(GetQuote());
        endScoreText.SetText(score.ToString(), true);
        return null;
    }

    private string GetQuote()
    {
        string quote = "";
        switch (score)
        {
            case var _ when score < 200:
                quote = "Nacho's are our last hope! Get them";
                break;
            case var _ when score < 500:
                quote = "If your partner won't buy you nachos it's not real love.";
                break;
            case var _ when score < 600:
                quote = "Nacho cheese is like cheese ,but for nachos";
                break;
            case var _ when score < 800:
                quote = "When a 99 Pound Person eats 1 Pound Nacho ,the person is 1% Nacho !";
                break;
            case var _ when score >=1000:
                quote = "Never ask a nacho about their dreams, it's Nacho Business !";
                break;
            case var _ when score >=1200:
                quote = "You have beaten the developer! Twitter to me @CodeChrisB";
                break;
            case var _ when score >= 5000:
                quote = "It's nacho business, but this time you OWN the Nacho Business !";
                break;
        }
        return quote;
    }


    private void ShowEndUI()
    {
        LeanTween.cancelAll();
    }
}
