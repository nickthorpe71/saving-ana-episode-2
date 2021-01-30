using System.Collections.Generic;
using UnityEngine;

public class Context : MonoBehaviour
{
    public bool gameStarted = false;

    public StoryNode currentNode;

    public string[] currentBountyClues;
    public string[] currentScannerData;

    private static Context _instance;

    public static Context Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public Dictionary<string, string> clues = new Dictionary<string, string>()
    {
        {"Topps", "clue about bounty"},
        {"Zella", "clue about bounty"},
        {"Anigun", "clue about bounty"},
    };


    public Dictionary<string, Character> scannerData = new Dictionary<string, Character>()
    {
        {"Topps", new Character { name="Glenn (Uno) Topps", description="Wears a ragged brown cloak which covers his face. All that portrudes from the hood is a lit cigarette and a red glow from what looks to be where one of his eyes might be.", occupation="N/A"} },
        {"Zella", new Character { name="Zella Stingwray", description="", occupation="CEO of IronNori - the largest mining company in the galaxy"} },
        {"Anigun", new Character { name="Anigun", description="", occupation="Bartender"} },
    };
}

public class Character
{
    public string name { get; set; }
    public string description { get; set; }
    public string occupation { get; set; }
};
