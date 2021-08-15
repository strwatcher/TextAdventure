using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RoomNavigation : MonoBehaviour
{
    private string _walkingMessage = "You head of to the ";
    private string _cantWalkMessage = "There is no path to the ";
    
    public Room currentRoom;

    private Dictionary<string, Room> exitDictionary = new Dictionary<string, Room>();
    private GameController _controller;

    private void Awake()
    {
        _controller = GetComponent<GameController>();
    }

    public void UnpackExitsInRoom()
    {
        foreach (var roomExit in currentRoom.exits)
        {
            exitDictionary.Add(roomExit.keyString, roomExit.connectedRoom);
           _controller.roomInteractions.Add(roomExit.exitDescription); 
        }
    }

    public void AttemptToChangeRooms(string directionNoun)
    {
        if (exitDictionary.ContainsKey(directionNoun))
        {
            currentRoom = exitDictionary[directionNoun];
            _controller.LogStringWithReturn(_walkingMessage + directionNoun); 
            _controller.DisplayRoomText();
        }
        else
        {
            _controller.LogStringWithReturn(_cantWalkMessage + directionNoun);
        }
    }

    public void ClearExits()
    {
        exitDictionary.Clear();
    }
}
