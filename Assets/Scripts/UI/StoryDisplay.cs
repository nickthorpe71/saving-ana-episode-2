using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoryDisplay : MonoBehaviour
{
    public GameObject bountyCluePrefab;
    public GameObject scannerDataPrefab;
    public GameObject choicePrefab;

    public Transform bountyList;
    public Transform scannerList;
    public Transform choiceList;

    private StoryNode currentNode;

    private DialogBoxAnimator dialogAnimator;

    void Start()
    {
        currentNode = Context.Instance.currentNode;

        dialogAnimator = GetComponent<DialogBoxAnimator>();
        dialogAnimator.AnimateDialogueBox(currentNode.text);
        dialogAnimator.storyDisplay = this;

        PopulateList(bountyCluePrefab, Context.Instance.currentBountyClues.Length, bountyList);
        PopulateList(scannerDataPrefab, Context.Instance.currentScannerData.Length, scannerList);
        // PopulateList(scannerDataPrefab, currentNode.choices.length);
    }

    void PopulateList(GameObject prefab, int quantity, Transform transform)
    {
        GameObject newObj;

        for (int i = 0; i < quantity; i++)
        {
            newObj = (GameObject)Instantiate(prefab, transform);
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
