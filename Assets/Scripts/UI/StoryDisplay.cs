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

    public TMP_Text dialogueTextBox;

    public ListCounter bountyCounter;
    public ListCounter scanCounter;

    void Start()
    {
        bountyCounter.UpdateCount(Context.Instance.currentBountyClues.Count);
        scanCounter.UpdateCount(Context.Instance.currentScannerData.Count);

        if (Context.Instance.currentNode != null)
            currentNode = Context.Instance.currentNode;
        else
            currentNode = lobbyNode;

        Context.Instance.storyDisplay = this;

        backgroundImage.sprite = currentNode.image;

        dialogAnimator = GetComponent<DialogBoxAnimator>();
        dialogAnimator.AnimateDialogueBox(currentNode.text);
        dialogAnimator.storyDisplay = this;
        newDialog(currentNode.text);

        ReloadScannerList();
        ReloadBountyList();
    }

    public void newDialog(string newText)
    {
        dialogAnimator.AnimateDialogueBox(newText);
    }

    void PopulateList(GameObject prefab, List<string> listArray, Transform transform)
    {
        GameObject newObj;

        for (int i = 0; i < listArray.Count; i++)
        {
            newObj = (GameObject)Instantiate(prefab, transform);
            newObj.GetComponent<TextSetter>().SetText(listArray[i]);
        }

        bountyCounter.UpdateCount(Context.Instance.currentBountyClues.Count);
        scanCounter.UpdateCount(Context.Instance.currentScannerData.Count);
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

    public void Reload(string newScene)
    {
        StartCoroutine(ReloadAsynchronously(newScene));
    }

    public void ReloadBountyList()
    {
        PopulateList(bountyCluePrefab, Context.Instance.currentBountyClues, bountyList);
    }

    public void ReloadScannerList()
    {
        PopulateList(scannerDataPrefab, Context.Instance.currentScannerData, scannerList);
    }

    IEnumerator ReloadAsynchronously(string newScene)
    { 
        AsyncOperation operation = SceneManager.LoadSceneAsync(newScene);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            loadingBar.value = progress;

            yield return null;
        }
    }
}
