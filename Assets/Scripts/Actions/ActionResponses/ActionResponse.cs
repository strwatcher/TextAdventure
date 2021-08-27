using Console;
using Environment;
using UnityEngine;

namespace Actions.ActionResponses
{
    public abstract class ActionResponse : ScriptableObject
    {
        [SerializeField] private string factor;
        
        public Messages messages;
        public string GetFactor => factor;
        public abstract bool GetActionResponse(RoomPackager env, Output cout);
    }
}