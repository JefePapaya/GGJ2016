using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WordManager : MonoBehaviour {

    public string ritualSentence;
    public Text currentText;
    public Text answerText;

    RearrangeWord rearrangeWord;
    
    string[] shuffledWords;
    string[] wordList;
    string currentWord; //shuffled Word
    int charIndex = 0;
    public int wordIndex = 0;
    bool canDisplayText = true;

    void Awake() {
    }

	// Use this for initialization
	void Start () {
        wordList = ritualSentence.Split();
        shuffledWords = RearrangeWord.ShuffleWords(ritualSentence);
        currentWord = shuffledWords[wordIndex];
        GameManager.sharedInstance.newWord(currentWord);
        //randomText = rearrangeWord.randomText;
        // answerText.text = rearrangeWord.targetText;
    }

    // Update is called once per frame
    void Update()
    {
        if (charIndex < currentWord.Length)
        {
            if (Input.GetKeyDown(currentWord[charIndex].ToString().ToLower()))
            {
                charIndex++;
                Debug.Log("Correct answer! " + charIndex);
            }
            else if (Input.anyKeyDown)
            {
                Debug.Log("WROOOOOOOONG MOTHERFUCKER");
                GameManager.sharedInstance.Mistype();
                
            }
        }
        else if (charIndex == currentWord.Length)
        {
            if (wordIndex >= wordList.Length)
            {
                return;
            }

            GameManager.sharedInstance.wordCompleted(wordIndex, wordList[wordIndex]);
            wordIndex++;
            charIndex = 0;
            if (wordIndex < shuffledWords.Length)
            {
                currentWord = shuffledWords[wordIndex];
                GameManager.sharedInstance.newWord(currentWord);
            }
            else if (wordIndex >= shuffledWords.Length)
            {
                GameManager.sharedInstance.Win("REACHED DIABOLIC");
            }
        }
    }
}
