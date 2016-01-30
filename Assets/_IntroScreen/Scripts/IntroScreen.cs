using UnityEngine;
using System.Collections;

public class IntroScreen : MonoBehaviour {

    public float timer = 2.0f;

    void Update(){
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Application.LoadLevel("MainMenu");
        }
    }
}
