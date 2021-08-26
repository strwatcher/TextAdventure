using Console;
using Environment;
using Items;
using UnityEngine;

namespace Actions
{
    [CreateAssetMenu(menuName = "TextAdventure/Actions/Inventory")]
    public class Inventory : InputAction
    {
        public override void RespondToInput(RoomPackager env, Output cout, string[] command)
        {
            string message = "";
            foreach (var item in env.savedEnvironment.items)
            {
                if (item.state.Equals(ItemState.InInventory))
                {
                    message += $"{cout.pointSign} {item.GetKey}\n";
                } 
            }
            cout.LogOutput(messages.GenerateMessage(messages.successTemplate, ":"));
            cout.LogOutput(message);
        }
    }
}