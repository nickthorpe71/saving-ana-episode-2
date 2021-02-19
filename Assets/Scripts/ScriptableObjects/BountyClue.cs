using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/StoryNodeScriptableObject", order = 1)]
public class BountyClue : ScriptableObject
{
    [TextArea(15, 20)]
    public string text;
}