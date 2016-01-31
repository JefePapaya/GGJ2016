using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
/*
    public void ChangeScene(string sceneName){
        SoundManager.sharedInstance.PlaySFX(SoundManager.CLICK);
        Invoke("CallScene", 0.2f);
    }

    private void CallScene()
    {
        Application.LoadLevel("Level_01");
    }*/

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            Application.LoadLevel("Level_01");
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Application.LoadLevel("Credits");
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Application.LoadLevel("Story");
        }
    }

}
