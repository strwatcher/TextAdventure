using Console;
using Environment;
using Items;
using UnityEngine;

namespace Actions
{
    [CreateAssetMenu(menuName = "TextAdventure/Actions/Take")]
    public class Take : InputAction
    {
        private void TryToTake(RoomPackager env, Output cout, string[] command)
        {
            if (env.UnpackedItems.ContainsKey(command[1]))
            {
                Item item = env.UnpackedItems[command[1]];
                if (item.GetSpawnRoomKey.Equals(env.savedEnvironment.room.GetKey) && !item.state.Equals(ItemState.InInventory))
                {
                    item.state = ItemState.InInventory;
                    cout.LogOutput(messages.GenerateMessage(messages.successTemplate, command[1]));
                    return;
                }
            }
            cout.LogOutput(messages.GenerateMessage(messages.failTemplate, command[1]));
        }
        
        public override void RespondToInput(RoomPackager env, Output cout, string[] command)
        {
           TryToTake(env, cout, command); 
        }
    }
}