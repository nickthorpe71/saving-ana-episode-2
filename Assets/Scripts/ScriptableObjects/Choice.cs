using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ChoiceScriptableObject", order = 2)]
public class Choice : ScriptableObject
{
    public string command;
    [TextArea(1,20)]
    public string description;
    public bool hasDialog;
    [TextArea(1,20)]
    public string dialog;
    public bool hasClue;
    public BountyClue clue;
    public bool hasScanData;
    public CharacterDescription scanData;
    public bool isWaypoint;
    public StoryNode nextNode;
}