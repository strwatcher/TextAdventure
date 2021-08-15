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
    
    private readonly List<string> _actionLog = new List<string>();
        
    private void Awake()
    {
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
    }

    private void ClearCollectionsForNewRoom()
    {
        roomInteractions.Clear();
        roomNavigation.ClearExits();
    }

    public void LogStringWithReturn(string stringToAdd)
    {
        _actionLog.Add(stringToAdd + "\n");
    }
}
