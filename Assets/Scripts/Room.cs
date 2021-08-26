using Items;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/Room")]
public class Room : ScriptableObject
{
    [SerializeField] private string key;
    [TextArea][SerializeField] private string description;
    public Exit[] exits;
    
    public string GetKey => key;
    public string GetDescription => description;
}
