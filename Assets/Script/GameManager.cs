using UnityEngine;
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

    void Awake ()
    {
        sharedInstance = this;
    }

    void Update()
    {
        CheckTensionLoseCondition();
        CheckTimeOutLoseCondition();
    }

    void CheckTimeOutLoseCondition()
    {
        if (timer.time <= 0)
        {
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
        anim.SetTrigger(StringConstants.SHAKE);
        CheckTensionLoseCondition();
    }

    void CheckTensionLoseCondition()
    {
        if (slider.value >= slider.maxValue)
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
        currentText.text = newWord;
    }

    public void Win()
    {
        if (timer.time > 0)
        {
            gameEnded = true;
            answerText.fontSize = 30;
            answerText.fontStyle = FontStyle.Normal;
            currentText.text = StringConstants.WIN;
            timer.SetFreeze(true);
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
