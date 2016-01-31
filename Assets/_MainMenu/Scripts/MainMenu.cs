using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
/*
    public void ChangeScene(string sceneName){

        Application.LoadLevel("Level_01");
    }*/

    void Update()
    {
        if (Input.GetKeyDown("space")){
            Application.LoadLevel("Level_01");
        }
    }

}
