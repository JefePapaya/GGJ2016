using UnityEngine;
using System.Collections;

public class QuitGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
