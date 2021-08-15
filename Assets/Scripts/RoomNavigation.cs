using UnityEngine;

public class RoomNavigation : MonoBehaviour
{
    public Room currentRoom;
    private GameController _controller;

    private void Awake()
    {
        _controller = GetComponent<GameController>();
    }

    public void UnpackExitsInRoom()
    {
        foreach (var roomExit in currentRoom.exits)
        {
           _controller.roomInteractions.Add(roomExit.exitDescription); 
        }
    }
}
