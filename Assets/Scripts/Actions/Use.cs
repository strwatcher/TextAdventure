using Console;
using Environment;
using Items;
using UnityEngine;

namespace Actions
{
    [CreateAssetMenu(menuName = "TextAdventure/Actions/Use")]
    public class Use : InputAction
    {
        private void TryToUse(RoomPackager env, Output cout, string[] command)
        {
            if (env.UnpackedItems.ContainsKey(command[1]) && 
                env.UnpackedItems[command[1]].state.Equals(ItemState.InInventory))
            {
                if (TryToTakeActionResponse(env.UnpackedItems[command[1]], env, cout)) return;
            }
            cout.LogOutput(messages.GenerateMessage(messages.failTemplate, command[1]));
        }
        public override void RespondToInput(RoomPackager env, Output cout, string[] command)
        {
            TryToUse(env, cout, command);
        }
    }
}