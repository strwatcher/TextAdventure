using UnityEngine;

namespace Actions
{
    public abstract class ActionResponse : ScriptableObject
    {
        [SerializeField] private string factor;
    
        public string GetFactor => factor;
        public abstract bool IsActionAllowed();
    }
}