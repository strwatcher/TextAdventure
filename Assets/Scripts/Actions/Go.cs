using Console;
using Environment;
using UnityEngine;

namespace Actions
{
    [CreateAssetMenu(menuName = "TextAdventure/Actions/Go")]
    public class Go : InputAction
    {
        // Move literals to constants
        private void TryChangeRoom(RoomPackager roomPackager, Output cout, string direction)
        {
            if (roomPackager.UnpackedExits.ContainsKey(direction))
            {
                roomPackager.SwitchRoom(roomPackager.UnpackedExits[direction]);
                cout.LogOutput(messages.GenerateMessage(messages.successTemplate, direction));
                cout.LogRoom(roomPackager);
            }
            else
            {
                cout.LogOutput(messages.GenerateMessage(messages.failTemplate, direction));
            }
        }
        
        public override void RespondToInput(RoomPackager env, Output cout, string[] command)
        {
            TryChangeRoom(env, cout, command[1]);
        }
    }
}