using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class WordManager : MonoBehaviour {

    //public List<string> listOfStrings_en = new List<string>;
    //public string ritualSentence = listOfStrings_en.(1);

    public string ritualSentence;
    public Text currentText;
    public Text answerText;

    RearrangeWord rearrangeWord;
    
    string[] shuffledWords;
    string[] wordList;
    string currentWord; //shuffled Word
    int charIndex = 0;
    public int wordIndex = 0;

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
            }
            else if (Input.anyKeyDown)
            {
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
                GameManager.sharedInstance.Win();
            }
        }
    }
}
