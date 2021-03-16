using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChoiceButton : MonoBehaviour
{
    public TMP_Text text;
    [HideInInspector] public Choice choice;
    [HideInInspector] public StoryDisplay storyDisplay;

    public void SetText(string newText)
    {
        text.text = newText;
        StartCoroutine(FadeTextToFullAlpha(1.5f));
    }
    public IEnumerator FadeTextToFullAlpha(float t)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        while (text.color.a < 1.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }

    public void onClick()
    {
        Context ctxt = Context.Instance;

        if (choice.hasDialog)
        {
            storyDisplay.newDialog(choice.dialog);

            if (choice.hasClue)
                ctxt.AddClue(choice.clue.text);
                
            else if (choice.hasScanData)
                ctxt.AddScanData(choice.scanData.text);
        }
        else if (choice.isWaypoint)
        {
            ChooseNextNode(ctxt);

            if(choice.nextNode.name == "EndChase") 
                storyDisplay.Reload("Chase Arcade");
            else
                storyDisplay.Reload("Travel Short");
        }
        else
        {
            ChooseNextNode(ctxt);
            storyDisplay.Reload("Story");
        }
    }

    private void ChooseNextNode(Context ctxt) 
    {
        if (choice.nextNode.name == "Port3Locked" && ctxt.currentBountyClues.Count >= ctxt.totalBountyClues)
        {
            ctxt.currentNode = ctxt.p403Unlocked;
        }
        else
        {
            ctxt.currentNode = choice.nextNode;
        }
    }
}
