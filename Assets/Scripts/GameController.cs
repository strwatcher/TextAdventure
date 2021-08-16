using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    public Text displayText;
    public InputAction[] inputActions;
    
    [HideInInspector] public RoomNavigation roomNavigation;
    [HideInInspector] public List<string> roomInteractions;
    [HideInInspector] public InteractableItems interactableItems;
    
    private readonly List<string> _actionLog = new List<string>();
        
    private void Awake()
    {
        interactableItems = GetComponent<InteractableItems>();
        roomNavigation = GetComponent<RoomNavigation>();
        roomInteractions = new List<string>();
    }

    private void Start()
    {
       DisplayRoomText();
       DisplayLoggedText();
    }

    public void DisplayLoggedText()
    {
        string logAsText = string.Join("\n", _actionLog.ToArray());

        displayText.text = logAsText;
    }

    public void DisplayRoomText()
    {
        ClearCollectionsForNewRoom();
        UnpackRoom();
        
        string joinedInteractions = String.Join("\n", roomInteractions.ToArray());
        string combinedText = roomNavigation.currentRoom.description + "\n" + joinedInteractions;
        
        LogStringWithReturn(combinedText);
    }

    private void UnpackRoom()
    {
        roomNavigation.UnpackExitsInRoom();
        PrepareObjectsToTakeOrExamine(roomNavigation.currentRoom);
    }

    private void PrepareObjectsToTakeOrExamine(Room current)
    {
        foreach (var item in current.InteractableObjects)
        {
            string descriptionNotInventoried = interactableItems.GetNotInventoriedItem(item);
            if (descriptionNotInventoried != null)
            {
                roomInteractions.Add(descriptionNotInventoried);
            }

            foreach (var interaction in item.interactions)
            {
                if (interaction.inputAction.actionType.Equals(ActionType.Examine))
                {
                    interactableItems.examineDictionary.Add(item.noun, interaction.textResponse);
                }

                if (interaction.inputAction.actionType.Equals(ActionType.Take))
                {
                    interactableItems.takeDictionary.Add(item.noun, interaction.textResponse);
                }
            }
        } 
    }

    public string TestVerbDictionaryWithNoun(Dictionary<string, string> verbDictionary, string verb, string noun)
    {
        if (verbDictionary.ContainsKey(noun))
        {
            return verbDictionary[noun];
        }

        return $"You can't {verb} {noun}";  
    }

    private void ClearCollectionsForNewRoom()
    {
        roomInteractions.Clear();
        roomNavigation.ClearExits();
        interactableItems.ClearCollections();
    }

    public void LogStringWithReturn(string stringToAdd)
    {
        _actionLog.Add(stringToAdd + "\n");
    }
}
