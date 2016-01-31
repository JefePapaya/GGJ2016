using UnityEngine;
using System.Collections;

public class BackgroundMusic : MonoBehaviour {

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
        SoundManager.sharedInstance.PlayBGTheme();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
