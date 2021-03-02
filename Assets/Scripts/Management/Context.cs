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
        // need to make sure we don't already have clue
        currentBountyClues.Add(clue);
        storyDisplay.ReloadSideMenus();
    }

    public void AddScanData(string data) {
        // need to make sure we don't already have data
        currentScannerData.Add(data);
        storyDisplay.ReloadSideMenus();
    }   
}