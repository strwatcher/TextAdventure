using Environment;
using UnityEngine;

namespace Actions
{
    public abstract class InputAction : ScriptableObject
    {
        [SerializeField] private string key;
        public Messages messages;
        private string TryToGetActionResponse()
        {
            return "";
        }
        
        public string GetKey => key;
        public abstract void RespondToInput(RoomPackager env, Console.Output cout, string[] command);
        
    }
}