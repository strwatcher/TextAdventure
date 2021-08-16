using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/Interactable object")]
public class InteractableObject : ScriptableObject
{
    public string noun = "name";
    
    [TextArea] public string description = "Description in room";

    public Interaction[] interactions;
}
