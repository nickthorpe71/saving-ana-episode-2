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
        if (choice.hasDialog)
        {
            storyDisplay.newDialog(choice.dialog);
        }
        else if (choice.isWaypoint)
        {
            Context.Instance.currentNode = choice.nextNode;
            storyDisplay.Reload("Travel");
        }
        else
        {
            Context.Instance.currentNode = choice.nextNode;
            storyDisplay.Reload("Story");
        }

        if (choice.hasClue)
        {
            Context.Instance.AddClue(choice.clue.text);
        }

        if (choice.hasScanData)
        {
            Context.Instance.AddScanData(choice.scanData.text);
        }

    }
}
