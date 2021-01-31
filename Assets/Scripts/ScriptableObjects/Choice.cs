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
    public bool isWaypoint;
    public StoryNode nextNode;
}