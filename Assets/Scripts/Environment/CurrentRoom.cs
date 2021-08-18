using System.Collections.Generic;
using UnityEngine;

namespace Environment
{
    public class CurrentRoom : MonoBehaviour
    {
        public Room room;
        
        [HideInInspector] public List<string> interactions = new List<string>();
        public readonly Dictionary<string, Room> UnpackedExits = new Dictionary<string, Room>();

        private void Awake()
        {
            UnpackExits();
        }

        private void UnpackExits()
        {
            foreach (Exit roomExit in room.exits)
            {
                UnpackedExits.Add(roomExit.GetKey, roomExit.GetLeadsTo);
                interactions.Add(roomExit.GetDescription);
            }
        }

        public void SwitchRoom(Room newRoom)
        {
            room = newRoom;
            UnpackedExits.Clear();
            interactions.Clear();
            UnpackExits();
        }
    }
    
}
