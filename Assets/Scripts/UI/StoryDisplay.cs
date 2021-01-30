using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoryDisplay : MonoBehaviour
{
    // populate choices, dialog, bounty clues, and scanner data
    // trigger dialog to start animation
    // once animation is complete (or after a second or do) display choices

    public GameObject bountyCluePrefab;
    public GameObject scannerDataPrefab;
    public GameObject choicePrefab;

    public Transform bountyList;
    public Transform scannerList;
    public Transform choiceList;

    private StoryNode currentNode;

    public float dialogSpeed = 0.05f;
    public TMP_Text dialogueTextBox;

    void Start()
    {
        currentNode = Context.Instance.currentNode;
        AnimateDialogueBox(currentNode.text);

        PopulateList(bountyCluePrefab, Context.Instance.currentBountyClues.Length, bountyList);
        PopulateList(scannerDataPrefab, Context.Instance.currentScannerData.Length, scannerList);
        // PopulateList(scannerDataPrefab, currentNode.choices.length);
    }

    void Update()
    {
        //Simple controls to accelerate the text speed.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            dialogSpeed = dialogSpeed / 100;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            dialogSpeed = 0.05f;
        }
    }

    public void AnimateDialogueBox(string text)
    {
        StartCoroutine(AnimateTextCoroutine(text));
    }

    private IEnumerator AnimateTextCoroutine(string text)
    {
        dialogueTextBox.text = "";
        int i = 0;

        while (i < text.Length)
        {
            dialogueTextBox.text += text[i];
            i++;
            yield return new WaitForSeconds(dialogSpeed);
        }
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
