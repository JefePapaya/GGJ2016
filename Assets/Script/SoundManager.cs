using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    public static SoundManager sharedInstance;
	public AudioClip[] sfxList;
	public AudioClip bgAudio;

	public static int CLICK = 0;
	public static int GAME_OVER = 1;
	public static int MISTAKE = 2;
	public static int SUCCESS = 3;
	public static int DOG = 4;
	public static int PHONE_RING = 5;
	public static int DIABOLICAT = 6;
	public static int PEEN = 7;
	public static int DISTRACT = 8;
	public static int YAWN = 9;
	public static int ALERT = 10;
	public static int RANDOM_WORDS = 11;

	private int direction;
	private float maxVolume;

	public bool loopBG = true;

    void Awake()
    {
        if (SoundManager.sharedInstance == null)  {
            sharedInstance = this;
        }
    }

	void Start()
	{
        if (SoundManager.sharedInstance != this)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
		GetComponent<AudioSource> ().loop = loopBG;
		//PlayMusicScene ();
	}
	
	public void PlayMusicScene()
	{
		GetComponent<AudioSource>().Play ();
	}
	
	public void PlaySFX(int index)
	{
		Vector2 position = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width/2, Screen.height/2));
		
		PlayClipAt (sfxList [index], new Vector3 (position.x, position.y, 0), gameObject);
	}

	public void PlayAudioClip(AudioClip clip)
	{
		Vector2 position = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width/2, Screen.height/2));
		
		PlayClipAt (clip, new Vector3 (position.x, position.y, 0));
	}

	public void PlayClipAt(AudioClip clip, Vector3 pos, GameObject parent = null)
	{
		GameObject temporaryObject = new GameObject ();
		temporaryObject.name = "TemporaryAudio";
		temporaryObject.transform.position = pos;
		if(parent != null) temporaryObject.transform.parent = parent.transform;
		AudioSource audioSource = temporaryObject.AddComponent<AudioSource>();
		audioSource.clip = clip;
		audioSource.volume = 1f;
		audioSource.ignoreListenerPause = true;
		audioSource.Play();
		Destroy(temporaryObject, clip.length);
	}

	public void PauseTheme()
	{
		GetComponent<AudioSource> ().Pause ();
	}

	public void PlayTheme( AudioClip audio )
	{
		GetComponent<AudioSource> ().clip = audio;
		PlayMusicScene ();
	}

	public void PlayBGTheme()
	{
		GetComponent<AudioSource> ().clip = bgAudio;
		PlayMusicScene ();
	}

	public void BeginFade( int dir )
	{
		direction = dir;
		InvokeRepeating ("Fade", 0f, 0.25f);
	}
	private void Fade()
	{
		if(direction > 0) // fade in
		{
			if(GetComponent<AudioSource> ().volume < maxVolume)
			{
				GetComponent<AudioSource> ().volume += 0.07f;
			}
			else CancelInvoke();
		}
		else // fade out
		{
			if(GetComponent<AudioSource> ().volume >= 0.07)
			{
				GetComponent<AudioSource> ().volume -= 0.07f;
			}
			else
			{
				GetComponent<AudioSource> ().volume = 0f;
				CancelInvoke();
			}
		}
	}
}
