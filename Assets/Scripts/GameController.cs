using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    public Text displayText;
    
    [HideInInspector] public RoomNavigation roomNavigation;
    
    private List<string> _actionLog = new List<string>();
    private void Awake()
    {
        roomNavigation = GetComponent<RoomNavigation>();
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
        string combinedText = roomNavigation.currentRoom.description + "\n";
        LogStringWithReturn(combinedText);
    }

    public void LogStringWithReturn(string stringToAdd)
    {
        _actionLog.Add(stringToAdd + "\n");
    }
}
