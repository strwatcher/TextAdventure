using Environment;
using UnityEngine;

namespace Actions
{
    public abstract class InputAction : ScriptableObject
    {
        [SerializeField] private string key;

        public string GetKey => key;
        
        public abstract void RespondToInput(CurrentRoom room, Console.Output cout, string[] command);
        
    }
}