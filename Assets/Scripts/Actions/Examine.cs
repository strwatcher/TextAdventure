using Console;
using Environment;
using Items;
using UnityEngine;

namespace Actions
{
    [CreateAssetMenu(menuName = "TextAdventure/Actions/Examine")]
    public class Examine : InputAction
    {
        private void TryToExamine(RoomPackager env, Output cout, string[] command)
        {
            if (env.UnpackedItems.ContainsKey(command[1]))
            {
                Item item = env.UnpackedItems[command[1]];
                if (item.GetSpawnRoomKey.Equals(env.savedEnvironment.room.GetKey) ||
                    item.state.Equals(ItemState.InInventory))
                {
                    foreach (Interaction interaction in item.GetInteractions)
                    {
                        if (interaction.GetAction.GetKey.Equals(command[0]))
                        {
                            cout.LogOutput(messages.GenerateMessage(messages.successTemplate, command[1]));
                            cout.LogOutput(interaction.GetResponseDescription);
                            return;
                        }
                    }
                }
            }
            cout.LogOutput(messages.GenerateMessage(messages.failTemplate, command[1]));
        }
        
        public override void RespondToInput(RoomPackager env, Output cout, string[] command)
        {
            TryToExamine(env, cout, command);
        }
    }
}