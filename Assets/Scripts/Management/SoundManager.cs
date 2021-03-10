using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
	public AudioSource MusicSource;
	public static SoundManager Instance = null;

    public AudioClip mainMusic;
    public AudioClip storyMusic;
    public AudioClip travelMusic;

    private int currentLevel = 5555;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else if (Instance != this)
		{
			Destroy(gameObject);
		}
		DontDestroyOnLoad (gameObject);
	}

    private void Start() 
    {
        CheckSceneMusic();
    }

    private void OnLevelWasLoaded(int level) 
    {
        Debug.Log("hit");

        if (level != currentLevel)
        {
            currentLevel = level;
            CheckSceneMusic();
        }
    }

    private void CheckSceneMusic()
    {
        switch (SceneManager.GetActiveScene().name)
            {
                case "Main":
                    PlayMusic(mainMusic);
                    break;
                case "Story":
                    PlayMusic(storyMusic);
                    break;
                case "Travel Short":
                    PlayMusic(travelMusic);
                    break;
            }
    }

	public void PlayMusic(AudioClip clip)
	{
		MusicSource.clip = clip;
		MusicSource.Play();
	}
}