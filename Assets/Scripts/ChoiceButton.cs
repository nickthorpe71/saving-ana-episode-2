using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChoiceButton : MonoBehaviour
{
    public TMP_Text text;
    public Choice choice;
    public StoryDisplay storyDisplay;

    public void SetText(string newText)
    {
        text.text = newText;
    }

    public void onClick()
    {
        if (choice.hasDialog)
        {
            storyDisplay.newDialog(choice.dialog);
        }
        else
        {
            Context.Instance.currentNode = choice.nextNode;
            storyDisplay.Reload();
        }
    }
}
