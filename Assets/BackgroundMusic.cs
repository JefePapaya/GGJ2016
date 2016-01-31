using UnityEngine;
using System.Collections;

public class BackgroundMusic : MonoBehaviour {
    
	// Use this for initialization
	void Start () {

        GameObject[] bgMusicObjects = GameObject.FindGameObjectsWithTag("BGMusic");

        if (bgMusicObjects.Length > 1)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        SoundManager.sharedInstance.PlayBGTheme();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
