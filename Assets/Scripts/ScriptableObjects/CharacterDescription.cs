using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CharacterDescriptionScriptableObject", order = 4)]
public class CharacterDescription : ScriptableObject
{
    public string target;
    [TextArea(15, 20)]
    public string text;
}