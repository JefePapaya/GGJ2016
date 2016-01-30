using UnityEngine;
using System.Collections;

public class Rune : MonoBehaviour {

    public Animator anim;
    
    public void Appear() {
        anim.SetTrigger("Appear");
    }
}
