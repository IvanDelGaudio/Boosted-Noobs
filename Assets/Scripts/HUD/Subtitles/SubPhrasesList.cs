using UnityEngine;

[CreateAssetMenu(fileName = "PhraseData", menuName = "Subtitle/Phrases list", order = 1)]
public class SubPhrasesList : ScriptableObject
{
    [TextArea]
    public string[] phrases;
}
