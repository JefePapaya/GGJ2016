using UnityEngine;
using System.Collections;

public class Fading : MonoBehaviour
{
	public Texture2D fadeOutTexture;
	public float fadeSpeed = 0.8f;
	
	private int drawDepth = -1000;
	private float alpha = 1.0f;
	private int fadeDir = -1;

	public bool isEnabled = true;

	

	private GameObject fade;

	void Start()
	{
		if(isEnabled) BeginFade (-1);
	}

	void OnGUI()
{
		alpha += fadeDir * fadeSpeed * Time.deltaTime;
		alpha = Mathf.Clamp01 (alpha);
		
		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.depth = drawDepth;
		GUI.DrawTexture ( new Rect( 0, 0, Screen.width, Screen.height ), fadeOutTexture );
		
		if((alpha == 0) && fadeDir == -1)
		{
			this.enabled = false;
		}
	}

	public float BeginFade( int direction )
	{
		if(direction == -1) alpha = 1f;
		else alpha = 0f;
		fadeDir = direction;
		return( fadeSpeed );
	}
}
