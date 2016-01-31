using UnityEngine;
using System.Collections;

public class Story : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Application.LoadLevel("MainMenu");
        }
    }
}
