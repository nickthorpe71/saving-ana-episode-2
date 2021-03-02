using System.Collections.Generic;
using UnityEngine;

public class Context : MonoBehaviour
{
    public StoryNode currentNode;
    public bool isChase;

    public List<string> currentBountyClues = new List<string>();
    public List<string> currentScannerData = new List<string>();

    public StoryDisplay storyDisplay;

    private static Context _instance;
    public static Context Instance { get { return _instance; } }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void AddClue(string clue) {
        if (!currentBountyClues.Contains(clue))
        {
            currentBountyClues.Add(clue);
            storyDisplay.ReloadBountyList();
        }
    }

    public void AddScanData(string data) {
        if(!currentScannerData.Contains(data))
        {
            currentScannerData.Add(data);
            storyDisplay.ReloadScannerList();
        }
    }   
}