using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ChoiceScriptableObject", order = 2)]
public class Choice : ScriptableObject
{
    public string command;
    //TextAreaAttribute(int minLines, int maxLines);
    [TextArea(1,20)]
    public string description;
    public bool hasDialog;
    //TextAreaAttribute(int minLines, int maxLines);
    [TextArea(1,20)]
    public string dialog;
    public bool hasClue;
    // public BountyClue clue; // Need to make SO for BountyClue
    public bool isWaypoint;
    public StoryNode nextNode;
}