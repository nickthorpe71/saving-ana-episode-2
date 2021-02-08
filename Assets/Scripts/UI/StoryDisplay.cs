using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
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
    public bool choicesDisplayed = false;

    private StoryNode currentNode;

    private DialogBoxAnimator dialogAnimator;

    public Image backgroundImage;

    public GameObject loadingScreen;
    public Slider loadingBar;

    public StoryNode lobbyNode;

    void Start()
    {
        if (Context.Instance.currentNode != null)
            currentNode = Context.Instance.currentNode;
        else
            currentNode = lobbyNode;

        backgroundImage.sprite = currentNode.image;

        dialogAnimator = GetComponent<DialogBoxAnimator>();
        dialogAnimator.AnimateDialogueBox(currentNode.text);
        dialogAnimator.storyDisplay = this;

        PopulateList(bountyCluePrefab, Context.Instance.currentBountyClues, bountyList);
        PopulateList(scannerDataPrefab, Context.Instance.currentScannerData, scannerList);
    }

    public void newDialog(string newText)
    {
        dialogAnimator.AnimateDialogueBox(newText);
    }

    void PopulateList(GameObject prefab, string[] listArray, Transform transform)
    {
        GameObject newObj;

        for (int i = 0; i < listArray.Length; i++)
        {
            newObj = (GameObject)Instantiate(prefab, transform);
            newObj.GetComponent<TextSetter>().SetText(listArray[i]);
        }
    }

    public void DisplayChoices()
    {
        if (!choicesDisplayed)
        {
            PopulateChoiceList(choicePrefab, currentNode.choices, choiceList);
            choicesDisplayed = true;
        }
    }

    void PopulateChoiceList(GameObject prefab, Choice[] choiceArray, Transform transform)
    {
        GameObject newChoice;

        for (int i = 0; i < choiceArray.Length; i++)
        {
            newChoice = (GameObject)Instantiate(prefab, transform);
            newChoice.GetComponent<ChoiceButton>().SetText(choiceArray[i].command + " " + choiceArray[i].description);
            newChoice.GetComponent<ChoiceButton>().choice = choiceArray[i];
            newChoice.GetComponent<ChoiceButton>().storyDisplay = this;
        }
    }

    public void Reload()
    {
        StartCoroutine(ReloadAsynchronously());
    }


    // Load Bar synching animation
    IEnumerator ReloadAsynchronously()
    { // scene name is just the name of the current scene being loaded
        AsyncOperation operation = SceneManager.LoadSceneAsync("Story");

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            loadingBar.value = progress;

            yield return null;
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
