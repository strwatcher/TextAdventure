using Console;
using Environment;
using UnityEngine;

namespace Actions
{
    [CreateAssetMenu(menuName = "TextAdventure/Actions/WhereAmI")]
    public class WhereAmI : InputAction
    {
        public override void RespondToInput(RoomPackager env, Output cout, string[] command)
        {
            cout.LogRoom(env);
        }
    }
}