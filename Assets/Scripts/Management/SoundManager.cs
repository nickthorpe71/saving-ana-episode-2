using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
	public AudioSource MusicSource;
	public static SoundManager Instance = null;

    public AudioClip mainMusic;
    public AudioClip p401Music;
    public AudioClip p402Music;
    public AudioClip p403Music;
    public AudioClip travelMusic;
    public AudioClip chaseMusic;
    public AudioClip endMusic;

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
                    string storyNodeName = Context.Instance.currentNode.name;
                    PlayMusic(p401Music);
                    if(storyNodeName.Contains("End"))
                        PlayMusic(endMusic);
                    else if(storyNodeName == "Lobby" || storyNodeName == "Port401")
                        PlayMusic(p401Music);
                    else if(storyNodeName == "Port402")
                        PlayMusic(p402Music);
                    else if(storyNodeName == "Port403" || storyNodeName == "Port403Locked")
                        PlayMusic(p403Music);

                    break;

                case "Travel Short":
                    PlayMusic(travelMusic);
                    break;

                case "Chase":
                    PlayMusic(chaseMusic);
                    break;
            }
    }

	public void PlayMusic(AudioClip clip)
	{
		MusicSource.clip = clip;
		MusicSource.Play();
	}
}