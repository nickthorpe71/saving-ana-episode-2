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