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
        slider.value += 5 / timer.time;

        CheckTensionLoseCondition();

        if (timer.time <= 0 && !gameEnded)
        {
            GameOver("Time Out");
        }
    }

    public void Mistype()
    {
        if (gameEnded)
        {
            return;
        }

        slider.value += tension;
        anim.SetTrigger("Shake");
        CheckTensionLoseCondition();
    }

    void CheckTensionLoseCondition()
    {
        if (slider.value >= slider.maxValue)
        {
            GameOver("FFSSST! TENSION!");
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

    public void Win(string message)
    {
        if (timer.time > 0)
        {
            gameEnded = true;
            currentText.text = message;
            timer.SetFreeze(true);
        }
    }

    public void GameOver(string message)
    {
        gameEnded = true;
        currentText.text = message;
        timer.SetFreeze(true);
    }
}
