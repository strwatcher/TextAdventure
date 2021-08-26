using Items;
using UnityEngine;

namespace Environment
{
    [CreateAssetMenu(menuName = "TextAdventure/Player/SavedEnvironment")]
    public class SavedEnvironment : ScriptableObject
    {
        public Room room;
        public Item[] items;
    }
}