using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/Messages")]
public class Messages: ScriptableObject
{
    [TextArea] public string successTemplate;
    [TextArea] public string failTemplate;

    public string GenerateMessage(string template, string noun)
    {
        return $"{template} {noun}\n";
    }
}