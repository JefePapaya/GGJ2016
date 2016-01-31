using UnityEngine;
using System.Collections;

public class BgManager : MonoBehaviour {
    public AudioClip audioClip;
	// Use this for initialization
	void Start () {
        SoundManager.sharedInstance.PlayTheme(audioClip);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
