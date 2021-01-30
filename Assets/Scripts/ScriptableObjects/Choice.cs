using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ChoiceScriptableObject", order = 2)]
public class Choice : ScriptableObject
{
    public string command;
    public string description;
    public bool hasDialog;
    public string dialog;
    public bool isWaypoint;
    public StoryNode nextNode;
}