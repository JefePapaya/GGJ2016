using UnityEngine;
using System.Collections;

public class GameOverSound : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SoundManager.sharedInstance.PlaySFX(SoundManager.GAME_OVER);
    }
}
