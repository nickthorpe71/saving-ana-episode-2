using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/StoryNodeScriptableObject", order = 4)]
public class CharacterDescription : ScriptableObject
{
    [TextArea(15, 20)]
    public string text;
}