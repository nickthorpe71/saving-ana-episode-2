using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/StoryNodeScriptableObject", order = 1)]
public class StoryNode : ScriptableObject
{
    public string text;
    public Choice[] choices;
}