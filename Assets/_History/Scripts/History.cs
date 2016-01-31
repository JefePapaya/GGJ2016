using UnityEngine;
using System.Collections;

public class History : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Application.LoadLevel("MainMenu");
        }
    }
}
