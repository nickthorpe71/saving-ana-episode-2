using UnityEngine;
using UnityEngine.UI

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/StoryNodeScriptableObject", order = 1)]
public class StoryNode : ScriptableObject
{
    public string text;
    public Image image;
    public Choice[] choices;
}