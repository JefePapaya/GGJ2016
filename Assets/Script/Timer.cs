using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

    public float time;
    public Text timer;
    private bool frozen = false;
    // Update is called once per frame

    public void SetFreeze(bool freeze)
    {
        frozen = freeze;
    }

    void Update() {
        if (time > 0 && !frozen)
        {
            time -= Time.deltaTime;
            if (time < 10)
            {
                timer.text = "00:0" + (int)time;
            }
            else
            {
                timer.text = "00:" + (int)time;
            }
        }
	}
}
