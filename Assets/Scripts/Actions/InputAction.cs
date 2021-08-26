using Environment;
using Items;
using UnityEngine;

namespace Actions
{
    public abstract class InputAction : ScriptableObject
    {
        [SerializeField] private string key;
        public Messages messages;

        public void TryToTakeActionResponse(Item item, RoomPackager env, Console.Output cout)
        {
            foreach (Interaction interaction in item.GetInteractions)
            {
                if (interaction.GetAction.GetKey.Equals(key))
                {
                    if (interaction.GetActionResponse)
                    {
                        interaction.GetActionResponse.GetActionResponse(env, cout);
                    }
                }
            }
        }
        
        public string GetKey => key;
        public abstract void RespondToInput(RoomPackager env, Console.Output cout, string[] command);
        
    }
}