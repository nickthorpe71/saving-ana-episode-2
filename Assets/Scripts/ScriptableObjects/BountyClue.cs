using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BountyClueScriptableObject", order = 3)]
public class BountyClue : ScriptableObject
{
    public string giver;
    [TextArea(15, 20)]
    public string text;
}