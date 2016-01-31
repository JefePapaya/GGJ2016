using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager sharedInstance;
    public Text answerText;
    public Text currentText;
    public Animator cameraShakeAnim;
    public Animator atentionAnim;
    public Animator diabolicatAnim;
    public Slider slider;
    public Rune[] runes;
    public Timer timer;
    public int tension = 10;
    bool gameEnded = false;
    bool won = false;
    float gameOverTimer = 2f;
    float winTimer = 4f;

    int state;

    public float minRangeEvent = 5f;
    public float maxRangeEvent = 8f;

    void Awake ()
    {
        sharedInstance = this;
    }

    void Start ()
    {
        currentText.text = "";
        answerText.text = "";

        Invoke("DistractionEvent", Random.Range(minRangeEvent, maxRangeEvent));
    }

    private void DistractionEvent()
    {
       
        System.Random random = new System.Random();
        int randomIndex = random.Next(4, 6);
        SoundManager.sharedInstance.PlaySFX(randomIndex);
        slider.value += 200;
        TriggerDistractionEvent();

    }
    private void TriggerDistractionEvent()
    {
        //SoundManager.sharedInstance.PlaySFX(SoundManager.ALERT);
        atentionAnim.SetTrigger("DrawAtention");
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
            currentText.fontSize = 30;
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
        cameraShakeAnim.SetTrigger(StringConstants.SHAKE);
        TriggerDistractionEvent();
        diabolicatAnim.SetTrigger("Mistype");
        Invoke("GettingBackToNormal", 0.8f);
        CheckTensionLoseCondition();
    }

    void GettingBackToNormal()
    {
        diabolicatAnim.SetTrigger("Step" + state);
    }
    void CheckTensionLoseCondition()
    {
        if (slider.value >= slider.maxValue && !gameEnded)
        {
            atentionAnim.SetTrigger("AllAtention");
            currentText.fontSize = 30;
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
        diabolicatAnim.SetTrigger("Step" + (wordIndex + 2));
        state = wordIndex + 2;
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
            answerText.fontStyle = FontStyle.Bold;
            answerText.alignment = (TextAnchor)TextAlignment.Center;
            answerText.alignment = TextAnchor.MiddleCenter;
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
