using UnityEngine;

namespace Items
{
    [CreateAssetMenu(menuName = "TextAdventure/Item")]
    public class Item : ScriptableObject
    {
        [SerializeField] private string key;
        [SerializeField] private Interaction[] interactions;
        [SerializeField] private Room spawnRoom;
        [TextArea] [SerializeField] private string description;
        
        public ItemState state = ItemState.Default;
        public string GetKey => key;
        public string GetSpawnRoomKey => spawnRoom.GetKey;
        public string GetDescription => description;
        public Interaction[] GetInteractions => interactions;
    }
}