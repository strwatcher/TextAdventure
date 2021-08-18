using Console;
using Environment;
using UnityEngine;

namespace Actions
{
    [CreateAssetMenu(menuName = "TextAdventure/Actions/Go")]
    public class Go : InputAction
    {
        private void TryChangeRoom(CurrentRoom room, Output cout, string direction)
        {
            if (room.UnpackedExits.ContainsKey(direction))
            {
                room.SwitchRoom(room.UnpackedExits[direction]);
                cout.LogOutput($"Вы отправились на {direction}\n");
                cout.LogRoom(room);
            }
            else
            {
                cout.LogOutput($"Нет пути на {direction}\n");
            }
        }
        
        public override void RespondToInput(CurrentRoom room, Output cout, string[] command)
        {
            TryChangeRoom(room, cout, command[1]);
        }
    }
}