using System.Collections.Generic;
using UnityEngine;

public class Context : MonoBehaviour
{
    public bool gameStarted = false;

    public StoryNode currentNode;

    public string[] currentBountyClues;
    public string[] currentScannerData;
    // to calculate game completion at the end just determine if player has scanned all cannable things and collected all clues

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

    
}