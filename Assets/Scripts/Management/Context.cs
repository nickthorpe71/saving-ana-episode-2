using System.Collections.Generic;
using UnityEngine;

public class Context : MonoBehaviour
{
    public StoryNode currentNode;
    public StoryNode p403Unlocked;

    public bool isChase;

    public int totalBountyClues = 3;
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

            if (currentBountyClues.Count == totalBountyClues)
            {
                currentBountyClues.Add("Your bounty is at the port of Port403!");
            }

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