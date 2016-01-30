using UnityEngine;
using UnityEngine.UI;


public class RearrangeWord {

    public static string[] ShuffleWords(string words)
    {
        string[] wordsList = words.Split();
        string[] randomWords = new string[wordsList.Length];
        for (int i = 0; i < wordsList.Length; i++)
        {
            randomWords[i] = Shuffle(wordsList[i]);
        }

        return randomWords;
    }

    public static string Shuffle(string str)
    {
        char[] array = str.ToCharArray();
        System.Random rand = new System.Random();
        int n = array.Length;
        while (n > 1)
        {
            n--;
            int k = rand.Next(n-1);
            var value = array[k];
            array[k] = array[n];
            array[n] = value;
        }
        return new string(array);
    }


}
    

