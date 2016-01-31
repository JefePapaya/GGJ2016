using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

    public float timerOver = 1.5f;

    void Update()
    {
        timerOver -= Time.deltaTime;

        if (timerOver <= 0)
        {
            Application.LoadLevel("MainMenu");
        }
    }
}
