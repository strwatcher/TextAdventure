using System.Collections.Generic;
using Items;
// using Player;
using UnityEngine;

namespace Environment
{
    public class RoomPackager : MonoBehaviour
    {
        
        [HideInInspector] public List<string> interactions = new List<string>();
        public readonly Dictionary<string, Room> UnpackedExits = new Dictionary<string, Room>();
        public readonly Dictionary<string, Item> UnpackedItems = new Dictionary<string, Item>();
        public SavedEnvironment savedEnvironment;

        private void Awake()
        {
            UnpackItems();
            SwitchRoom(savedEnvironment.room);
            
        }

        private void UnpackExits()
        {
            foreach (Exit roomExit in savedEnvironment.room.exits)
            {
                UnpackedExits.Add(roomExit.GetKey, roomExit.GetLeadsTo);
                interactions.Add(roomExit.GetDescription);
            }
        }

        private void UnpackItems()
        {
            foreach (Item item in savedEnvironment.items)
            {
                UnpackedItems.Add(item.GetKey, item);
            }
        }

        private void AddItemsToInteractions()
        {
            foreach (Item item in savedEnvironment.items)
            {
                if (!item.state.Equals(ItemState.InInventory) && 
                    item.GetSpawnRoomKey.Equals(savedEnvironment.room.GetKey))
                { 
                    interactions.Add(item.GetDescription);
                }
            }
        }

        public void SwitchRoom(Room newRoom)
        {
            savedEnvironment.room = newRoom;
            UnpackedExits.Clear();
            interactions.Clear();
            AddItemsToInteractions();
            UnpackExits();
        }
    }
    
}
