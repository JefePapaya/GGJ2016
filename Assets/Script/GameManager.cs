﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager sharedInstance;
    public Text answerText;
    public Text currentText;
    public Animator anim;
    public Slider slider;
    public Rune[] runes;
    public Timer timer;
    public int tension = 10;
    bool gameEnded = false;
    bool won = false;
    float gameOverTimer = 2f;
    float winTimer = 4f;

    void Awake ()
    {
        sharedInstance = this;
    }

    void Update()
    {
        CheckTensionLoseCondition();
        CheckTimeOutLoseCondition();
        if (gameEnded && !won)
        {
            gameOverTimer -= Time.deltaTime;
            if(gameOverTimer <= 0)
            {
                Application.LoadLevel("GameOver");
            }
        }
        else if (gameEnded && won)
        {
            winTimer -= Time.deltaTime;
            if (winTimer <= 0)
            {
                Application.LoadLevel("MainMenu");
            }
        }
    }

    void CheckTimeOutLoseCondition()
    {
        if (timer.time <= 0 && !gameEnded)
        {
            SoundManager.sharedInstance.PlaySFX(SoundManager.PEEN);
            GameOver(StringConstants.TIMEOUT);
        }
    }

    public void Mistype()
    {
        if (gameEnded)
        {
            return;
        }

        slider.value += tension + 200/timer.time;
        SoundManager.sharedInstance.PlaySFX(SoundManager.MISTAKE);
        anim.SetTrigger(StringConstants.SHAKE);
        CheckTensionLoseCondition();
    }

    void CheckTensionLoseCondition()
    {
        if (slider.value >= slider.maxValue && !gameEnded)
        {
            GameOver(StringConstants.TENSION_LOSE);
        }
    }
	// Use this for initialization
	
    public void wordCompleted(int wordIndex, string completedWord)
    {
        if (gameEnded)
        {
            return;
        }
        
        runes[wordIndex].Appear();
        answerText.text += completedWord + " ";
        
    }

    public void newWord(string newWord)
    {
        if (!gameEnded)
        {
            currentText.text = newWord;
        }
    }

    public void Win()
    {
        if (timer.time > 0)
        {
            won = true;
            gameEnded = true;
            answerText.fontSize = 30;
            answerText.fontStyle = FontStyle.Normal;
            currentText.text = StringConstants.WIN;
            timer.SetFreeze(true);
            SoundManager.sharedInstance.PlaySFX(SoundManager.DIABOLICAT);
        }
    }

    public void GameOver(string message)
    {
        if (!gameEnded) {
            gameEnded = true;
            currentText.text = message;
            timer.SetFreeze(true);
        }
    }
}
