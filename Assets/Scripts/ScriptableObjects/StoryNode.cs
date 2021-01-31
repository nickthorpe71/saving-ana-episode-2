using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/StoryNodeScriptableObject", order = 1)]
public class StoryNode : ScriptableObject
{
    //TextAreaAttribute(int minLines, int maxLines);
    [TextArea(15,20)]
    public string text;
    public Sprite image;
    public Choice[] choices;
}