using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/StoryNodeScriptableObject", order = 3)]
public class BountyClue : ScriptableObject
{
    [TextArea(15, 20)]
    public string text;
}